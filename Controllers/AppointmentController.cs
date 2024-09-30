using AppointmentManagementUserApi.DataAccess;
using AppointmentManagementUserApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepos _appointmentRepos;

        public AppointmentController(IAppointmentRepos appointmentRepos)
        {
            _appointmentRepos = appointmentRepos;
        }

        [HttpGet("GetAllAppointment")]

        public List<AppointmentDTO> GetAllAppointment()
        {
            var i= _appointmentRepos.GetAllAppointment();
            return i;
        }
        [HttpGet("GetAppointmentById")]
        public Appointment GetAppointmentById(int id)
        {
            return _appointmentRepos.GetAppointmentById(id);
        }

        [HttpPost("AddAppointment")]
        public void PostAppointment([FromBody] AppointmentDTO appointmentDTO)
        {
            var appointment = new Appointment
            {
                AppointmentId = appointmentDTO.AppointmentId,
                DateTime = appointmentDTO.DateTime,
                Duration = appointmentDTO.Duration,
                DescriptionName = appointmentDTO.DescriptionName,
                UserId = appointmentDTO.UserId,

            };

            _appointmentRepos.AddAppointment(appointment);
        }

        [HttpPut("UpdateAppointment")]

        public bool Put(int appointmentId, AppointmentDTO appointmentDTO)
        {
            var appointment = _appointmentRepos.GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                return false;
            }
            appointment.DateTime = appointmentDTO.DateTime;
            appointment.Duration = appointmentDTO.Duration;
            appointment.DescriptionName = appointmentDTO.DescriptionName;
            appointmentDTO.UserId = appointment.UserId;
            
           

           
            _appointmentRepos.UpdateAppointment(appointment);
            return true;
        }

        [HttpDelete("DeleteAppointmentById")]
        public void DeleteAppointmentById(int id)
        {
            _appointmentRepos.DeleteAppointmentById(id);
        }




    }
}
