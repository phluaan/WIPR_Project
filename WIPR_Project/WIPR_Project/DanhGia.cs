using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class DanhGia
    {
        int id;
        int idTho;
        int idNguoiDung;
        decimal numOfStar;
        string userEvaluation;
        string job;
        public int Id { get { return id; } set { id = value; } }
        public int IdTho { get { return idTho; } set { idTho = value; } }
        public int IdNguoiDung { get { return idNguoiDung; } set { idNguoiDung = value; } }
        public decimal NumOfStar { get { return numOfStar; } set { numOfStar = value; } }
        public string UserEvaluation { get { return userEvaluation; } set { userEvaluation = value; } }
        public string Job { get { return job; } set { job = value; } }
        public DanhGia() { }
        public DanhGia(int id, int idTho, int idNguoiDung, decimal numOfStar, string userEvaluation, string job)
        {
            this.id = id;
            this.idTho = idTho;
            this.idNguoiDung = idNguoiDung;
            this.numOfStar = numOfStar;
            this.userEvaluation = userEvaluation;
            this.job = job;
        }
    }
}
