using ProjectsTasks.Application.Role.DTOs;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Role.UseCases
{
    public class GetDefaultsRolesUseCase : NullaryUseCase<ICollection<RoleOutput>>
    {
        private readonly IRoleRepository roleRepository;

        public GetDefaultsRolesUseCase(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public ICollection<RoleOutput> Execute()
        {
            var roles = roleRepository.GetUsersDefaultRole();
            return roles.Select(r => Mappers.FromRole(r)).ToArray();
        }
    }
}
