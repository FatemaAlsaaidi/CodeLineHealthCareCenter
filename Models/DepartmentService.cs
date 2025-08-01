﻿using CodeLineHealthCareCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeLineHealthCareCenter
{
    public class DepartmentService //// DepartmentService class that provides operations for Department objects directly
    {
        private List<Department> departments = new List<Department>(); // List to store all departments


        public DepartmentService(List<Department> departments)
        {
            this.departments = departments;
        }

        // 0. Add a new service to an existing department
        public void AddServiceToDepartment(int departmentId)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentId == departmentId); // Find the department by ID
            if (department == null)
            {
                Console.WriteLine(" Department not found.");
                return;
            }
            Console.Write("Enter service name: "); // Prompt user for service name
            string name = Console.ReadLine();

            Console.Write("Enter Clinic  Id: "); // Prompt user for  Clinic  Id
            int clinicId = int.Parse(Console.ReadLine());

            Console.Write("Enter service price: "); // Prompt user for service price
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine(" Invalid price entered.");
                return;
            }

            // Create and add the new service
            var newService = new Service
            {
                ServiceId = department.Services.Count + 1, // auto-increment id
                ServiceName = name,
                ClinicId = clinicId,
                Price = price
            };

            department.Services.Add(newService); // Add the new service to the department's service list
            Console.WriteLine(" Service added successfully to department.");
        }

        
        // 1. Get all departments
        public void GetAllDepartments()
        {
            if (departments.Count == 0) // Check if the list of departments is empty
            {
                Console.WriteLine(" No departments found.");
                return;
            }

            Console.WriteLine(" List of Departments:");
            // Iterate through each department and print its details
            foreach (var dept in departments)  // items is a List<Department> in the base class Service
            {
                Console.WriteLine($"ID: {dept.DepartmentId}, Name: {dept.DepartmentName}"); 
            }
        }

        // 2. Update department by ID
        public void UpdateDepartment(int departmentId)
        {
            var dept = departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (dept != null)
            {
                Console.Write("Enter new department name: "); // Prompt user for new department name
                dept.DepartmentName = Console.ReadLine();
                Console.WriteLine(" Department updated successfully.");
            }
            else
            {
                Console.WriteLine(" Department not found.");
            }
        }

        // 3. Set department active/inactive
        public void SetActiveStatus(int departmentId, bool isActive)
        {
            var dept = departments.FirstOrDefault(d => d.DepartmentId == departmentId); // Find the department by ID
            if (dept != null)
            {
                string status = isActive ? "Active" : "Inactive"; // Set the status based on isActive parameter
                Console.WriteLine($" Department '{dept.DepartmentName}' status set to {status}.");
            }
            else
            {
                Console.WriteLine("  Department not found."); 
            }
        }
        // 4. Get department by name
        public void GetDepartmentByName(string name) 
        {
            var dept = departments.FirstOrDefault(d => d.DepartmentName.Equals(name, StringComparison.OrdinalIgnoreCase)); // Find the department by name
            if (dept != null)
                Console.WriteLine($" Department Found: ID = {dept.DepartmentId}, Name = {dept.DepartmentName}"); 
            else
                Console.WriteLine(" Department not found.");
        }

        // 5. Get department by ID
        public void GetDepartmentById(int id)
        {
            var dept = departments.FirstOrDefault(d => d.DepartmentId == id); // Find the department by ID
            if (dept != null)
                Console.WriteLine($" Department Found: Name = {dept.DepartmentName}");
            else
                Console.WriteLine(" Department not found."); 
        }

        // 6. Get department name by ID (return string)
        public string GetDepartmentName(int id)
        {
            var dept = departments.FirstOrDefault(d => d.DepartmentId == id);
            return dept != null ? dept.DepartmentName : "Department not found.";
        }
    }


}

