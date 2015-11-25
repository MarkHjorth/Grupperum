using GrupperumServer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.CtrlLayer
{
    public class LoginCtrl
    {
        StudentCtrl studentCtrl = new StudentCtrl();
        public LoginCtrl()
        {
        }
        public bool Authenticate(int user, string password)
        {
            bool validated = false;

            Student student = studentCtrl.GetSudentById(user);
            int tempStudentId = student.Id;
            string tempPassword = student.Password;
            if (user == tempStudentId && password == tempPassword)
            {
                validated = true;
            }

            return validated;
        }
    }
}
