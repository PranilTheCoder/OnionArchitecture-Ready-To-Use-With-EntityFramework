using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace PranilArchitecture.Data
{
	public class UnitOfWork : IDisposable, IUnitOfWork
	{
		#region Private variables

		private TestEntities _context = null;
		private GenericRepository<ExpenseType> _expenseTypeRepository;
		private GenericRepository<MeetingSubject> _meetingSubjectRepository;

		private bool disposed = false;

		#endregion

		#region Constructor

		public UnitOfWork()
		{
			this._context = new TestEntities();
		}

		#endregion

		#region Public properties

		public GenericRepository<ExpenseType> ExpenseTypeRepository
        {
			get
			{
				if (this._expenseTypeRepository == null)
				{
					this._expenseTypeRepository = new GenericRepository<ExpenseType>(this._context);
				}

				return this._expenseTypeRepository;
			}
		}

		public GenericRepository<MeetingSubject> MeetingSubjectRepository
        {
			get
			{
				if (this._meetingSubjectRepository == null)
				{
					this._meetingSubjectRepository = new GenericRepository<MeetingSubject>(this._context);
				}

				return this._meetingSubjectRepository;
			}
		}

		#endregion

		#region Public methods

		public void Save()
		{
			try
			{
				this._context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				var outputLines = new List<string>();
				foreach (var eve in e.EntityValidationErrors)
				{
					outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));

					foreach (var ve in eve.ValidationErrors)
					{
						outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
					}
				}

				throw;
			}
		}

		#endregion

		#region Implementing IDiosposable
		
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					Debug.WriteLine("UnitOfWork is being disposed");
					this._context.Dispose();
				}
			}

			this.disposed = true;
		}

		#endregion
	}
}
