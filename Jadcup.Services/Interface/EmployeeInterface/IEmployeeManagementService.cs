using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.EmployeeModel;
using static Jadcup.Services.Model.EmployeeModel.EmployeeLogin;
using static Jadcup.Services.Model.EmployeeModel.EmployeeRegister;

namespace Jadcup.Services.Interface.EmployeeInterface
{
    public interface IEmployeeManagementService
    {
        Task<TaskResponse<int>> EmployeeRegister(EmployeeRegisterDto employee);
        Task<TaskResponse<EmployeeLoginResultDto>> EmployeeLogin(EmployeeLoginDto employeeLogin);
        Task<TaskResponse<List<GetEmployeeDto>>> GetAllEmployee();
        Task<TaskResponse<GetEmployeeDto>> GetEmployeeById(int id);
        Task<TaskResponse<int>> UpdateEmployee(UpdateEmployeeDto updatedEmployee);
        Task<TaskResponse<bool>> UpdateEmployeePassword(string password, string newPassword);
        Task<TaskResponse<bool>> DeleteEmployee(int id);
        Task<TaskResponse<bool>> VerifyPassword(EmployeeLoginDto request);
        Task<TaskResponse<bool>> ResetPassword(int employeeId, string password);
    }
}