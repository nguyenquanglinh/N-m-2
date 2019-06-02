#include<iostream>
#include <fstream>
#include <string>
using namespace std;

class KhachHang
{
	private:
		int ID;
		string CMTND;
		string TenKH;
		string GaDen;
		double GiaVe;
	public:
		KhachHang();
		KhachHang(int &ID, string &CMTND,string &TenKH,string &GaDen,double &GiaVe);
		
		void Nhap();
		void Xuat();
		
		void setID(int ID) {this->ID=ID;}
		void setCMTND(string CMTND) {this->CMTND=CMTND;}
		void setTenKH(string TenKH) {this->TenKH=TenKH;}
		void setGaDen(string GaDen) {this->GaDen=GaDen;}
		void setGiaVe(double GiaVe){this->GiaVe= GiaVe;}
		
		int getID(){return this->ID;}
		string getCMTND(){return this->CMTND;}
		string getTenKH(){return this->TenKH;}
		string getGaDen(){return this->GaDen;}
		double getGiaVe(){return this->GiaVe;}
		
};
KhachHang::KhachHang()
{
	this->ID=0;
	this->CMTND="";
	this->TenKH="";
	this->GaDen="";
	this->GiaVe=0;
}
KhachHang::KhachHang(int &ID,string &CMTND,string &TenKH,string &GaDen,double &GiaVe)
{
	this->ID=ID;
	this->CMTND=CMTND;
	this->TenKH=TenKH;
	this->GaDen=GaDen;
	this->GiaVe=GiaVe;
}
void KhachHang::Nhap()
{
	cout<<"NHAP THONG TIN KHACH HANG: "<<endl;
	cout<<"ID: ";cin>>this->ID;
	cout<<"TEN KH: ";fflush(stdin);getline(std::cin, this->TenKH);
	cout<<"CMTND: ";fflush(stdin);getline(std::cin, this->CMTND);
	cout<<"GA DEN: ";fflush(stdin);getline(std::cin, this->GaDen);
	cout<<"GIA VE: ";cin>>this->GiaVe;
}
void KhachHang::Xuat()
{
	cout<<"| ID: "<<this->ID<<"| TEN KH: "<<this->TenKH<<" | CMTND: "<<this->CMTND<<" | GA DEN: "<<this->GaDen<<" | GIA VE: "<<this->GiaVe<<" |"<<endl;
}

class DanhSach:public KhachHang
{
	public:
		int N;
		KhachHang *A;
	DanhSach();
	void Nhap();
	void Xuat();
	
	void Them();
	void Sua(int temp);
	void Xoa(int temp);
	void Sapxep();
	
};
DanhSach::DanhSach()
{
	this->N=0;
	A = new KhachHang[100];
}
void DanhSach::Nhap()
{
	for(int i=0;i<N;i++)
	{
		A[i].Nhap();
	}
}
void DanhSach::Xuat()
{
	for(int i=0;i<N;i++)
	{
		A[i].Xuat();
	}
}
void DanhSach::Them()
{
	if (N == 100)
	{
		cout<<"FULL";
		return;
	}
	else
	{
		A[N++].Nhap();
	}
}
void DanhSach::Sua(int temp)
{
	if(temp < 0 || temp > N) return;
	else
	{
		cout<<"NHAP LAI THONG TIN";
		A[temp].Nhap();
	}
	
}
void DanhSach::Xoa(int temp)
{
	if(temp < 0 || temp > N) return;
	else
	{
		for (int i = temp; i < N - 1; i++)
		{
			A[i] = A[i+1];
		}
		N--;
	}
	
}
void DanhSach::Sapxep()
{
	for(int i=0;i<N;i++)
	{
		if(A[i].getGiaVe()>A[i++].getGiaVe())
		{
			KhachHang temp = A[i];
			A[i]=A[i++];
			A[i++]=temp;
		}
	}
}
int main()
{
	DanhSach DS;
	int choice;
	cout<<"1. THEM KHACH HANG"<<endl;
	cout<<"2. IN KHACH HANG"<<endl;
	cout<<"3. XOA KHACH HANG"<<endl;
	cout<<"4. SUA KHACH HANG"<<endl;
	cout<<"5. SAP XEP"<<endl;
	cout<<"6. THOAT"<<endl;
	do{
	cout<<endl<<"BAN CHON: ";cin>>choice;
	switch(choice)
	{
		case 1:
			{
				DS.Them();
				break;
			}
		case 2:
			{
				DS.Xuat();
				break;
			}
		case 3:
			{
				cout<<"NHAP VAO ID CAN XOA: ";
				int temp; cin>>temp;
				DS.Xoa(temp-1);
				DS.Xuat();
				break;
			}
		case 4:
			{
				cout<<"NHAP VAO ID CAN SUA: ";
				int temp; cin>>temp;
				DS.Sua(temp-1);
				DS.Xuat();
				break;
			}
		case 5:
			{
				DS.Sapxep();
				DS.Xuat();
				break;
			}
		case 6:
			{
				break;
			}
		default: break;
	}
	}while(choice!=6);

}

