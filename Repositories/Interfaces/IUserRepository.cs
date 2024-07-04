using ResumeProject.DTOs.User;

namespace ResumeProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> InsertAsync(UserInsertDTO user);
        Task<int> UpdateAsync(int id, UserUpdateDTO user);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<UserGetDTO>> GetAllAsync();
        Task<UserGetDTO> GetByIdAsync(int id);
    }
}
