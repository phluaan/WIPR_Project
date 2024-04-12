using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class LoiMoi
    {
        int id;
        int idTho;
        int idNguoiDung;
        int idBaiViet;
        string sendfrom;
        DateTime dateWork;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdTho
        {
            get { return idTho; }
            set { idTho = value; }
        }
        public string Sendfrom
        {
            get { return sendfrom; }
            set { sendfrom = value; }
        }
        public DateTime DateWork
        {
            get { return dateWork; }
            set { dateWork = value; }
        }
        public int IdNguoiDung
        {
            get { return idNguoiDung; }
            set { idNguoiDung = value; }
        }
        public int IdBaiViet
        {
            get { return idBaiViet; }
            set { idBaiViet = value; }
        }
        public LoiMoi(int id,int idTho,int idNguoiDung,int idBaiViet,string sendfrom,DateTime dateWork)
        {
            this.id = id;
            this.idTho = idTho;
            this.idNguoiDung = idNguoiDung;
            this.idBaiViet = idBaiViet;
            this.sendfrom = sendfrom;
            this.dateWork = dateWork;
        }
        public LoiMoi()
        {

        }
    }
}
