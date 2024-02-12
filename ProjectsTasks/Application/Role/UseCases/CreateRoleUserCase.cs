using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Role
{
    public class CreateRoleUserCase : UnitUseCase<CreateRoleInput>
    {
        private readonly IRoleRepository roleRepository;

        public CreateRoleUserCase(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public void Execute(CreateRoleInput input)
        {
            var role = Mappers.FromRoleInput(input);
            roleRepository.Save(role);
        }
    }
}
