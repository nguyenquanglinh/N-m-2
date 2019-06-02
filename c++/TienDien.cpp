#include<iostream>
#include<conio.h>

using namespace std;

class KhachHang
{
	protected:
		string msThue;
		string maKh;
		string HoTen;
		string NgayNhap;
		string DiaChi;
		int SoKW;
		int DonGia;
		int GiaTien;
		int DinhMuc;
	public:
		KhachHang();
		KhachHang(string maKh, string HoTen, string NgayNhap, string DiaChi, int SoKW, int DonGia);
		~KhachHang();
};

KhachHang :: KhachHang()
{
	this->SoKW = 0;
	this->DonGia = 0;
}
KhachHang::KhachHang(string maKh, string HoTen, string NgayNhap, string DiaChi, int SoKw, int DonGia)
{
	this->maKh = maKh;
	this->HoTen = HoTen;
	this->NgayNhap = NgayNhap;
	this->DiaChi = DiaChi;
	this->SoKW = SoKw;
	this->DonGia = DonGia;
}
KhachHang::~KhachHang()
{
}

	//Ham thuoc tinh
//	string getmaKh();
//	void setmaKh(string maKh);
//	string getHoTen();
//	void setHoTen(string HoTen);
//	string getNgayNhap();
//	void setNgayNhap(string NgayNhap);
//	string getDiaChi();
//	void setDiaChi(string DiaChi);
//	int getSoKw();
//	void setSoKw(int SoKw);
//	int getDonGia();
//	void setDonGia(int DonGia);


//string KhachHang::getmaKh()
//{
//	return this->maKh;
//}
//void KhachHang::setmaKh(string maKh)
//{
//	this->maKh = maKh;
//}
//string KhachHang::getHoTen()
//{
//	return this->HoTen;
//}
//void KhachHang::setHoTen(string HoTen)
//{
//	this->HoTen = HoTen;
//}
//string KhachHang::getNgayNhap()
//{
//	return this->NgayNhap;
//}
//void KhachHang::setNgayNhap(string NgayNhap)
//{
//	this->NgayNhap = NgayNhap;
//}
//string KhachHang::getDiaChi()
//{
//	return this->DiaChi;
//}
//void KhachHang::setDiaChi(string DiaChi)
//{
//	this->DiaChi = DiaChi;
//}
//int KhachHang::getSoKw()
//{
//	return this->SoKW;
//}
//void KhachHang::setSoKw(int SoKw)
//{
//	this->SoKW = SoKw;
//}
//int KhachHang::getDonGia()
//{
//	return this->DonGia = DonGia;
//}
//void KhachHang::setDonGia(int DonGia)
//{
//	this->DonGia = DonGia;
//}

class KH_HoGD : public KhachHang
{
	private:
		int DinhMuc;
		int GiaTien;
		int SoKW;
		int DonGia;
	public:
		void Nhap();
		void Xuat();
		int ThanhTien();
};

void KH_HoGD::Nhap()
{
	cout<<"Moi ban nhap thong tin Khach Hang: \n";
	cout<<"Ma KH: "; cin>>this->maKh;
	cout<<"Ho Ten: "; cin>>this->HoTen;
	fflush(stdin);
	cout<<"Ngay nhap: "; getline(cin,NgayNhap);
	cout<<"Dia Chi: "; cin>>this->DiaChi;
	cout<<"So KW: "; cin>>this->SoKW;
	cout<<"Don gia: "; cin>>this->DonGia;
	cout<<"Dinh Muc: "; cin>>this->DinhMuc;
	if(SoKW <= DinhMuc)
	{
		this->GiaTien = this->SoKW*this->DonGia;
	}else{
		this->GiaTien = this->SoKW*this->DonGia*this->DinhMuc + (this->SoKW - this->DinhMuc)*this->DonGia*2.5;
	}
}

int KH_HoGD::ThanhTien()
{
	if(SoKW <= DinhMuc)
	{
		this->GiaTien = this->SoKW*this->DonGia;
		return this->GiaTien;
	}else{
		this->GiaTien = this->SoKW*this->DonGia*this->DinhMuc + (this->SoKW - this->DinhMuc)*this->DonGia*2.5;
		return this->GiaTien;
	}
}

void KH_HoGD::Xuat()
{
	cout<<"Thong tin Hoa Don Dien cua K.hang: \n";
	cout<<"Ma KH: "<<this->maKh<<endl;
	cout<<"Ho Ten: "<<this->HoTen<<endl;
	cout<<"Ngay nhap: "<<this->NgayNhap<<endl;
	cout<<"Dia Chi: "<<this->DiaChi<<endl;
	cout<<"So KW: "<<this->SoKW<<endl;
	cout<<"Don gia: "<<this->DonGia<<endl;
	cout<<"=> Thanh tien: "<<this->GiaTien<<endl;
	cout<<endl;
}

class KH_DN : public KhachHang
{
	private:
		string msThue;
		int DinhMuc;
		int GiaTien;
		int SoKW;
		int DonGia;
	public:
		void Nhap();
		void Xuat();
		int ThanhTien();
};

void KH_DN::Nhap()
{
	cout<<"Moi ban nhap thong tin Khach Hang: \n";
	cout<<"Ma KH: "; cin>>this->maKh;
	cout<<"Ten DN: "; cin>>this->HoTen;
	cout<<"MS Thue: "; cin>>this->msThue;
	fflush(stdin);
	cout<<"Ngay nhap: "; getline(cin,NgayNhap);
	cout<<"Dia Chi: "; cin>>this->DiaChi;
	cout<<"So KW: "; cin>>this->SoKW;
	cout<<"Don gia: "; cin>>this->DonGia;
	this->GiaTien = this->SoKW*this->DonGia;
}

int KH_DN::ThanhTien()
{
	this->GiaTien=this->SoKW*this->DonGia;
	return this->GiaTien;

}

void KH_DN::Xuat()
{
	cout<<"Thong tin Hoa Don Dien cua K.hang: \n";
	cout<<"Ma KH: "<<this->maKh<<endl;
	cout<<"Ten DN: "<<this->HoTen<<endl;
	cout<<"MS Thue: "<<this->msThue;
	cout<<"Ngay nhap: "<<this->NgayNhap<<endl;
	cout<<"Dia Chi: "<<this->DiaChi<<endl;
	cout<<"So KW: "<<this->SoKW<<endl;
	cout<<"Don gia: "<<this->DonGia<<endl;
	cout<<"=> Thanh tien: "<<this->GiaTien<<endl;
	cout<<endl;
}

class dsHoaDon : public KhachHang
{
	private:
		int N,M;
		KH_HoGD a[100];
		KH_DN b[100];
		float sum=0;
	public:
		void Nhap();
		void Xuat();
		void Them(KhachHang obj);
		void Sua(KhachHang obj, int K);
		void Xoa(int K);
		int TimKiem(int MaSach);
		void SapXep();
		KhachHang TimMax();
		void TongTienDien_DN();
};

void dsHoaDon::Nhap()
{
	cout<<"Nhap so luong HoGD N = ";
	cin>>N;
	for(int i=1 ; i<= N; i++){
		a[i].Nhap();
	}
	cout<<"\nNhap so luong DN M = ";
	cin>>M;
	for(int i=1 ; i<= M; i++){
		b[i].Nhap();
	}
}

void dsHoaDon::Xuat()
{
	cout<<"++++++++++++++++++++++++++++++++++++++++++\n";
	cout<<"DANH SACH HOA DON TIEN DIEN:\n";
	for(int i=1 ; i<= N; i++){
		a[i].Xuat();
	}
	cout<<endl;
	for(int i=1 ; i<= M; i++){
		b[i].Xuat();
	}
}

void dsHoaDon::Them(KhachHang obj)
{
	if(N == 1000)
	{
		cout<<"Danh sach da tran bo nho. Khong them duoc!";
	}else{
		a[N] = obj;
		N++;
	}
}

void dsHoaDon::Sua(KhachHang obj, int K)
{
	if((K>=N) || (K<0)) 
	{
		cout<<"Khong sua duoc doi tuong, vi tri khong hop le!!!";
		
	}else{
		a[K] = obj;
	}
}

void dsHoaDon::Xoa(int K)
{
	if((K>=N) || (K<0))
	{
		cout<<"Khong xoa duoc doi tuong, vi tri khong hop le!!!";
	}else{
		for(int i = K; i<N-1;i++){
			a[i]= a[i-1];
		}
		N--;
	}
}

int dsHoaDon::TimKiem(int maKh)
{
	for(int i=0; i<N; i++){
		if(a[i].getmaKh() == maKh)
			return i;
	}
	return -1;
}

void dsHoaDon::ThanhTien()
{
	
}

int main()
{
	
}
