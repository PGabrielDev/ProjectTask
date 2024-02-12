﻿using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Project
{
    public class GetAllProjectsUseCase : NullaryUseCase<List<ProjectOutput>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsUseCase(IProjectRepository repository)
        {
            _repository = repository;
        }

        public List<ProjectOutput> Execute()
        {
            var projects = _repository.GetAll();
            return projects.Select(Mappers.FromProject).ToList();
        }
    }
}
