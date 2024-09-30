using AppointmentManagementUserApi.Models;

namespace AppointmentManagementUserApi.DataAccess
{
    public interface IAppointmentRepos
    {
        public List<AppointmentDTO> GetAllAppointment();
        public Appointment GetAppointmentById(int id);
        public void DeleteAppointmentById(int id);
        public void UpdateAppointment(Appointment model);
        public void AddAppointment (Appointment model);

        //public void IsAppointmentOverlapping(int userId,DateTime dateTime,int duration);

    }
}
