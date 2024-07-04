using Dapper;
using Npgsql;
using ResumeProject.DTOs.User;
using ResumeProject.Repositories.Interfaces;

namespace ResumeProject.Repositories.Implements
{
    public class UserRepository:IUserRepository
    {
        private readonly NpgsqlConnection _connection;

        public UserRepository(NpgsqlConnection connection) { _connection = connection; }

        public async Task<int> InsertAsync(UserInsertDTO user)
        {
            var query = "Insert INTO public.user (name,surname,email,profile_description, phone_number,birthplace, nationality,is_deleted) Values (:name,:surname,:email,:profile_description, :phone_number, :birthplace, :nationality,false)";
            var result = await _connection.ExecuteAsync(query, new {name = user.Name ,surname = user.Surname, email = user.Email,profile_description = user.Profile_Description,phone_number = user.Phone_Number,birthplace = user.Birthplace,nationality = user.Nationality});
            if(result == 0)
            {
                throw new Exception("Cannot create");
            }
            return result;
        }
        public Task<int> UpdateAsync(int id, UserUpdateDTO user)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserGetDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserGetDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
