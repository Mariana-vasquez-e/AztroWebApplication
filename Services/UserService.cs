using AztroWebApplication.Data;
using AztroWebApplication.Models;
using AztroWebApplication.Repositories;

namespace AztroWebApplication.Services
{
    public class UserService
    {

        private readonly UserRepository userRepository;

        public UserService(ApplicationDbContext context)
        {
            userRepository = new UserRepository(context);
        }

        // Metodo para obtener todos los usuarios
        public async Task<List<User>> GetAllUsers()
        {
            // llama al repositorio para traer la informacion de la base de datos
            return await userRepository.GetAllUsers();
        }

        // Metodo para obtener un usuario por su id
        public async Task<User?> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);
        }

        // Metodo para crear un usuario
        public async Task<User?> CreateUser(User user)
        {
            // Valida que la edad del usuario sea mayor a 18 y menor a 80
            if (user.Age < 18 || user.Age > 80)
            {
                return null;
            }
            // llama al repositorio para crear un nuevo usuario
            return await userRepository.CreateUser(user);
        }

        // Metodo para actualizar un usuario por su id
        public async Task<User?> UpdateUserById(int id, User user)
        {
            return await userRepository.UpdateUserById(id, user);
        }

        // Metodo para eliminar un usuario por su id
        public async Task<User?> DeleteUserById(int id)
        {
            return await userRepository.DeleteUserById(id);
        }
    }
}