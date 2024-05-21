
import requests
import json
import socket


def is_port_open(port, host="127.0.0.1", timeout=2):
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.settimeout(timeout)
    result = sock.connect_ex((host, port))
    sock.close()
    return result == 0  


def load_json_data(json_file_path):
    try:
        with open(json_file_path, "r") as file:
            return json.load(file)
    except Exception as e:
        print(f"Error reading JSON file: {e}")
        return None


def create_employees(api_url, employee_data):
    if employee_data is None:
        print("No employee data to process.")
        return False

    success = True
    i = 0
    for employee in employee_data:
        response = requests.post(api_url, json=employee)
        
        if response.status_code == 200 or response.status_code == 201:
            i += 1
            continue

        print(
            f"Failed to add employee: {employee['name']} {employee['surName']}. "
            f"Status code: {response.status_code}"
        )
        return False
        

    print(f"Successfully added {i} employees.")
    return success


port = 5095  
if not is_port_open(port):
    print(f"Please run a server.")
    exit(1)


json_file_path = "./data/employees.json" 
api_url = "http://127.0.0.1:5095/api/employee/create"

employee_data = load_json_data(json_file_path)

if create_employees(api_url, employee_data):
    print("Successfully added all employees.")
else:
    print("Some employees could not be added.")
