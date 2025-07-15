using System.Collections.Generic;
using SO_OMS.Domain.Entities;

namespace SO_OMS.Application.Interfaces
{
	public interface IAlertLogRepository
	{
		List<AlertLog> GetAll();
		void Update(AlertLog alertLog);
	}
}
