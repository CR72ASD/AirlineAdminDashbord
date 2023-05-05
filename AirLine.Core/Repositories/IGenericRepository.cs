using AirLine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(int id);
		Task<IReadOnlyList<T>> GetAllAsync();
		Task AddAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
		Task<int> Complete();
		Task<IReadOnlyList<Employee>> GetAllEmployeesAsync();
		Task<IReadOnlyList<PortsTo>> GetAllPortsToAsync();
		Task<IReadOnlyList<PortsFrom>> GetAllPortsFromAsync();
	}
}
