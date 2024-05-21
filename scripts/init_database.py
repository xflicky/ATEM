import subprocess
import os
import socket


def is_port_open(port, host="127.0.0.1", timeout=2):
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.settimeout(timeout)
    result = sock.connect_ex((host, port))
    sock.close()
    return result == 0  


def run_command(command, working_directory, input=None):
    result = subprocess.run(
        command,
        cwd=working_directory,
        capture_output=True,
        text=True,
        input=input,
    )

    if result.returncode != 0:
        print(f"Error executing command: {command}")
        print(f"Error message: {result.stderr}")
        return False
    else:
        print(' '.join(command))
        print('Done successfully\n')
        return True


def init_db(working_directory):
    print('Initializing database...\n')

    print("Removing Migrations directory...")
    if not run_command(["rm", "-rf", "Migrations/"], working_directory):
        return False

    print("Dropping the existing database...")
    if not run_command(["dotnet", "ef", "database", "drop", "--force"], working_directory, input="y\n"):
        return False

    print("Adding initial migration...")
    if not run_command(["dotnet", "ef", "migrations", "add", "init"], working_directory):
        return False

    print("Updating the database...")
    if not run_command(["dotnet", "ef", "database", "update"], working_directory):
        return False

    print("Database setup completed successfully.")
    return True




port = 5095  
if is_port_open(port):
    print(f"Please kill a server.")
    exit(1)


api_directory = "../api/"  
if not os.path.exists(api_directory):
    raise FileNotFoundError(f"Directory {api_directory} does not exist")

working_directory = os.path.abspath(api_directory)

init_db(working_directory)
