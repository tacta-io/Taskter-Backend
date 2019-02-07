﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectTaskEntryRepository : IRepository<ProjectTaskEntry>
    {
        Task<ProjectTaskEntry> AddTimeEntry(ProjectTaskEntry newProjectTaskEntry);
        Task<IEnumerable<ProjectTaskEntry>> GetProjectTaskEntriesForCurrentUserByDate( int year, int month, int day);
    }
}
