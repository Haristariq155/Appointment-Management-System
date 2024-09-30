using AppointmentManagementUserApi.Models;

namespace AppointmentManagementUserApi.DataAccess
{
    public class AppointmentRepos : IAppointmentRepos
    {
        private readonly AppointmentUserDBContext _dbContext;

        public AppointmentRepos(AppointmentUserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAppointment(Appointment model)
        {
            //_dbContext.Appointments.Add(model);
            //_dbContext.SaveChanges();

            var obj = new Appointment();
            obj.DateTime = model.DateTime;
            obj.Duration = model.Duration;
            obj.DescriptionName = model.DescriptionName;
            obj.UserId = model.UserId;

            _dbContext.Appointments.Add(model);
            _dbContext.SaveChanges();
        }

        public void DeleteAppointmentById(int id)
        {
            var appointment = _dbContext.Appointments.Remove(GetAppointmentById(id));
            if (appointment != null)
            {
                _dbContext.SaveChanges();
            }
        }

        public List<AppointmentDTO> GetAllAppointment()
        {
            var appointments = new List<AppointmentDTO>();


            var resultList= _dbContext.Appointments.ToList();

            foreach (var item in resultList)
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO();
                appointmentDTO.AppointmentId= item.AppointmentId;
                appointmentDTO.DateTime = item.DateTime;
                appointmentDTO.Duration = item.Duration;
                appointmentDTO.DescriptionName = item.DescriptionName;
                appointmentDTO.UserId = item.UserId;
                appointments.Add(appointmentDTO);



            }



            return appointments;
 

        }

        public Appointment GetAppointmentById(int id)
        {
           Appointment appointment = _dbContext.Appointments.FirstOrDefault(x=>x.AppointmentId == id);
            return appointment;
        }

        public void UpdateAppointment(Appointment model)
        {
            var obj = new Appointment();
            obj.DateTime = model.DateTime;
            obj.Duration = model.Duration;
            obj.DescriptionName = model.DescriptionName;
            obj.UserId = model.UserId;

            _dbContext.Appointments.Update(model);
            _dbContext.SaveChanges();
        }
    }
}
