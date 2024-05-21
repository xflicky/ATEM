import json
import random
from faker import Faker
from datetime import datetime, timedelta

# Create an instance of Faker for Slovakian locale
fake = Faker('sk_SK')

# Function to generate a random birth date for a person around 30 ± 5 years old
def random_birth_date(min_age=25, max_age=35):
    current_year = datetime.now().year
    random_age = random.randint(min_age, max_age)
    birth_year = current_year - random_age
    # Generate a random day of the year for birth date
    birth_date = datetime(birth_year, random.randint(1, 12), random.randint(1, 28))
    return birth_date.isoformat()

# List to store employee data
employees = []

# Generate 30 employees with Slovakian names and other details
for _ in range(30):
    employee = {
        "name": fake.first_name(),
        "surName": fake.last_name(),
        "birthDate": random_birth_date(),
        "address": fake.address().replace('\n', ', '),
        "email": fake.email(),
        "phone": fake.phone_number()
    }
    employees.append(employee)

# Write the generated employee data to a JSON file
with open('employees.json', 'w') as json_file:
    json.dump(employees, json_file, indent=4)

print("Generated employee data saved to employees.json")
