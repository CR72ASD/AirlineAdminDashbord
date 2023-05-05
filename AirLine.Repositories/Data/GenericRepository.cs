using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Repositories.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly DBAContext _context;

		public GenericRepository(DBAContext context)
		{
			_context = context;
		}

		public async Task AddAsync(T entity)
			=> await _context.AddAsync(entity);

		public async Task<int> Complete()
			=> await _context.SaveChangesAsync();

		public void Delete(T entity)
			=> _context.Remove(entity);

		public async Task<IReadOnlyList<T>> GetAllAsync()
			=> await _context.Set<T>().ToListAsync();

		public async Task<IReadOnlyList<Employee>> GetAllEmployeesAsync()
			=> await _context.Employees.Include(d => d.Department).ToListAsync();

		public async Task<IReadOnlyList<PortsFrom>> GetAllPortsFromAsync()
			=> await _context.PortsFrom.Include(d => d.Country).ToListAsync();

		public async Task<IReadOnlyList<PortsTo>> GetAllPortsToAsync()
			=> await _context.PortsTo.Include(d => d.Country).ToListAsync();

		public async Task<T> GetByIdAsync(int id)
			=> await _context.Set<T>().FindAsync(id);

		public void Update(T entity)
			=> _context.Update(entity);
	}
}
