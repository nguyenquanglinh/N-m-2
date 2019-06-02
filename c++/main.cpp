#include <iostream>
#include <string.h>
#include <string>
#include <vector>
#include <fstream>
#include <conio.h>
#include<stdio.h>
#include <windows.h>
#include <stdlib.h>
#include<iomanip>

void textcolor(WORD color);
using namespace std;
int Key=0;
void Nocursortype()//ham an con tro
{
	CONSOLE_CURSOR_INFO Info;
	Info.bVisible = FALSE;
	Info.dwSize = 20;
	SetConsoleCursorInfo(GetStdHandle(STD_OUTPUT_HANDLE), &Info);
}
void Cursortype()//ham hien con tro
{
	CONSOLE_CURSOR_INFO Info;
	Info.bVisible = TRUE;
	Info.dwSize = 20;
	SetConsoleCursorInfo(GetStdHandle(STD_OUTPUT_HANDLE), &Info);
}
void textcolor(WORD color)//ham doi mau chu
{
    HANDLE hConsoleOutput;
    hConsoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);
    CONSOLE_SCREEN_BUFFER_INFO screen_buffer_info;
    GetConsoleScreenBufferInfo(hConsoleOutput, &screen_buffer_info);
    WORD wAttributes = screen_buffer_info.wAttributes;
    color &=0x000f;
    wAttributes &=0xfff0; wAttributes |=color;
    SetConsoleTextAttribute(hConsoleOutput,wAttributes);
}

void gotoxy(int x,int y)
{
    static HANDLE h=NULL;
    if(!h)
        h=GetStdHandle(STD_OUTPUT_HANDLE);
    COORD menu = {x,y};
    SetConsoleCursorPosition(h,menu);
}
void kekhung(int x, int y, int d, int n){
	gotoxy(x,y); cout << char(218);
	for(int i=0 ; i<n ; i++ ){
		cout << char(196);
	}
	cout << char(191) << endl;
	for(int i=0 ; i<d ; i++ ){
		gotoxy(x,y+1+i);
		cout << char(179);
		for(int j=0 ; j<n ; j++ ){
			cout << " ";
		}
		cout << char(179) << endl;
	}
	gotoxy(x,y+1+d); cout << char(192);
	for(int i=0 ; i<n ; i++ ){
		cout << char(196);
	}
	cout << char(217) << endl;
}
void kehang(int n){
	for(int i=0 ; i<n ; i++ ){
		cout << char(196);
	}
}
void KeDS(int n)
{
    textcolor(2);
    char s[]="DANH SACH SINH VIEN";
    char a[]="STT";char b[]="MA LOP";char c[]="MA SV";char d[]="HO VA TEN";
    char e[]="NGAY SINH";char f[]="DIEM TB";
    gotoxy(0,3); cout<<char(218); kehang(100);cout<<char(191)<<endl;
    gotoxy(0,4); cout<<char(179); gotoxy(40,4); cout<<s;
    gotoxy(101,4); cout<<char(179);
    gotoxy(0,5); cout<<char(195); kehang(8); cout<<char(194); kehang(15);
    cout<<char(194); kehang(15); cout<<char(194); kehang(30); cout<<char(194);
    kehang(17); cout<<char(194); kehang(10); cout<<char(180);
    gotoxy(3,6); cout<<a; gotoxy(15,6); cout<<b; gotoxy(32,6); cout<<c;
    gotoxy(52,6); cout<<d; gotoxy(78,6); cout<<e; gotoxy(93,6); cout<<f;
    for(int i=0;i<n;i++){
		gotoxy(0,7+i+i);cout << char(195);
		kehang(8); cout<<char(197); kehang(15); cout<<char(197); kehang(15); cout<<char(197);
	    kehang(30); cout<<char(197); kehang(17); cout<<char(197); kehang(10);cout << char(180);
    }
    for(int i=0;i<2*n+1;i=i+2){
    	gotoxy(0,6+i); cout<<char(179); gotoxy(9,6+i); cout<<char(179); gotoxy(25,6+i); cout<<char(179);
    	gotoxy(41,6+i); cout<<char(179); gotoxy(72,6+i); cout<<char(179); gotoxy(90,6+i); cout<<char(179);
    	gotoxy(101,6+i); cout<<char(179);
	}
	gotoxy(0,2*n+7); cout<<char(192); kehang(100); gotoxy(9,2*n+7); cout<<char(193); gotoxy(25,2*n+7); cout<<char(193);
	gotoxy(41,2*n+7); cout<<char(193); gotoxy(72,2*n+7); cout<<char(193); gotoxy(90,2*n+7); cout<<char(193); gotoxy(101,2*n+7); cout<<char(217);
}

void ToMau(int x, int y, string a, int color,int color1)
{
	gotoxy(x, y);
	textcolor(color);
	cout << a;
	textcolor(color1);
}
struct SinhVien
{
    char MaLop[10];
	char MSV[10];
	char HoTen[50];
	char Ngaysinh[50];
	char Ngay[10],Thang[10],Nam[10];
	int ngay,thang,nam;
	float diem;
};
const string MenuChinh[]={
	"1> THEM MOI HO SO SINH VIEN\n",
	"2> IN DANH SACH SINH VIEN\n",
	"3> SAP XEP SINH VIEN\n",
	"4> TIM KIEM SINH VIEN\n",
	"5> THONG KE SINH VIEN\n",
	"6> THOAT"
};
const string Muc1_Nhap[]={
	" + MA LOP: \n",
	" + MA SINH VIEN: \n",
	" + HO VA TEN: \n",
	" + NGAY SINH: \n",
	" + DIEM TB TICH LUY: \n"
};
const string Muc3_Sapxep[]={
	" > SAP XEP CHON\n",
	" > SAP XEP CHEN\n",
	" > SAP XEP NHANH\n",
    " > SAP XEP NOI BOI\n"
};
const string muc4_con[]={
    " + MA LOP: \n",
	" + MA SINH VIEN: \n",
	" + HO VA TEN: \n",
	" + NGAY SINH: \n",
 	" + DIEM TB TICH LUY: \n"
};
const string Muc4_TimKiem[]={
	" > TIM KIEM TUAN TU\n"
	//" > TIM KIEM NHI PHAN\n"
};
const string Muc5_Thongke[]={
	"> THEO LOP\n",
	"> THEO KET QUA HOC TAP\n"
};
void Intieude(){
	gotoxy(30,0);
	printf("**************************************************\n\n");
	char menu[]="---QUAN LY SINH VIEN---";
	gotoxy(44,1);
	printf("%s",menu);
	gotoxy(30,2);
	printf("**************************************************\n\n");
}
void InMang(const string Mang[],int n,int Opt)
{
    textcolor(2);
    Intieude();
    for(int i=1;i<=n;i++)
    {

        if(i==Opt){
            ToMau(0,7+2*i,Mang[i-1],3,7);//s°ía ¡ß ây Ã cách dòng
            continue;
        }
        else{
            textcolor(2);
            gotoxy(0,7+2*i);//s°ía car ¡ß ây Ã cách dòng
            cout<<Mang[i-1];
        }
    }
}
void strdel(char *s,int vt,int sl)// xoa ki tu o vi tri vt, s1 la vt xet cuoi
{
    int n=strlen(s),i;
    for (i=vt;i<=n-sl;++i)
        s[i]=s[i+sl];
}
void chuanhoachuoi(char a[])
{
    int n=strlen(a);
    while(a[n-1]==' ')
        a[n-1]=0;
    while(a[0]==' ')
        strdel(a,0,1);
    for(int i=0;i<n;i++)//chuyển tất cả về chữ thường
    {
        if(a[i]>=65&&a[i]<=90)
            a[i]=a[i]+32;
    }
    for(int i=0;i<n;i++)//xoá 2 khoảng trắng liên tiêp
    {
        if(a[i]==' '&&a[i+1]==' ')
            strcpy(&a[i],&a[i+1]);
    }
    for(int i=0;i<n;i++)//chuyển chữ cái sau dấu cách thành in hoa
    {
        if(a[i]==' ')
            a[i+1]=toupper(a[i+1]);//chuyển chữ cái đầu thành in hoa
    }
    a[0]=toupper(a[0]);
}
void XLNgay(SinhVien* sv)
{
    strncpy(sv->Ngay,sv->Ngaysinh,2);
	strncpy(sv->Thang,sv->Ngaysinh+3,2);
	strncpy(sv->Nam,sv->Ngaysinh+6,4);
	sv->ngay=atoi(sv->Ngay);
	sv->thang=atoi(sv->Thang);
	sv->nam=atoi(sv->Nam);
}
int KTngay(SinhVien sv)
{
    int check=0;
	XLNgay(&sv);
	if(sv.nam>=1){
		if((sv.thang==1||sv.thang==3||sv.thang==5||sv.thang==7||sv.thang==8||sv.thang==10||sv.thang==12)&&(sv.ngay>=1&&sv.ngay<=31))
			check=1;
		else if((sv.thang==4||sv.thang==6||sv.thang==9||sv.thang==11)&&(sv.ngay>=1&&sv.ngay<=30))
			check=1;
		else if	(sv.thang==2&&(sv.ngay>=1&&sv.ngay<=28))
			check=1;
		else if(sv.nam%400==0||(sv.nam%4==0&&sv.nam%100!=0)&&(sv.thang==2&&(sv.ngay>=1&&sv.ngay<=29)))
			check=1;
		else check=0;
	}
	return check;
}
SinhVien NhapHoSo()
{
	Cursortype();
	SinhVien sv;
    for (int j=1; j<6;j++){//ke khung
    	textcolor(2);
 		gotoxy(21,7+2*j); printf("%c",186);
 		gotoxy(51,7+2*j); printf("%c",186);
	}
	textcolor(12);
	gotoxy(22,9);
	fflush(stdin);
	gets(sv.MaLop);
	again11:
	    gotoxy(22,11);
	    fflush(stdin);
	    cin>>sv.MSV;
    if(strlen(sv.MSV)!=8){//MSV gom 8 chu so
        goto again11;
    }
    gotoxy(22,13);
    fflush(stdin);
    gets(sv.HoTen);
    again12:
        gotoxy(22,15);
        fflush(stdin);
        gets(sv.Ngaysinh);
	int check=KTngay(sv);
	if(check==0){
        goto again12;
    }
    again13:
        gotoxy(22,17);
        fflush(stdin);
        cin>>sv.diem;
	if(sv.diem<0||sv.diem>4){
		gotoxy(20,20);
		cout<<"Diem nhap vao khong hop le";
		goto again13;
	}
    Nocursortype();
	chuanhoachuoi(sv.HoTen);
    gotoxy(20,22);
    printf("\tNhap du lieu cua %s thanh cong !",sv.HoTen);
    return sv;
}
void InDSCon(vector<SinhVien> SV,int stt,int sotrang)
{
    textcolor(15);
    int j=0;
    for(int i=stt-1;i<stt+9;i++){
        gotoxy(4,8+2*j); cout<<i+1; gotoxy(14,8+2*j); cout<<SV[i].MaLop; gotoxy(30,8+2*j); cout<<SV[i].MSV;
        gotoxy(48,8+2*j); cout<<SV[i].HoTen; gotoxy(77,8+2*j); cout<<SV[i].Ngaysinh; gotoxy(94,8+2*j); cout<<SV[i].diem;
        j++;
        if(i==(SV.size()-1))
            break;
    }
    textcolor(2);
    int trang=(stt%10==0&&stt!=0)?stt/10:stt/10+1;
    gotoxy(40,28); cout<<"<<"<<trang<<"/"<<sotrang<<">>";
}
void InDS(vector<SinhVien> SV)
{
    int n=SV.size();
    int sotrang = (n%10==0&&n!=0)?n/10:n/10+1;
    int a=1;
    if(sotrang==1) KeDS(n);
    else KeDS(10);
    InDSCon(SV,a,sotrang);
    while(1){
        int k=getch();
        if(k==77){
            a=a+10;
            if(a<n+1){
                system("cls");
                if(n-a<10) KeDS(n%10);
                else KeDS(10);
                InDSCon(SV,a,sotrang);
            }else{
                a=1;
                system("cls");
                KeDS(10);
                InDSCon(SV,a,sotrang);
            }
        }else if(k==75){
            a=a-10;
            if(a>=1){
                system("cls");
                KeDS(10);
                InDSCon(SV,a,sotrang);
            }else{
                for(int i=0;i<sotrang;i++){
					a=a+10;
				}
				system("cls");
				if(n-a<10) KeDS(n%10);
                else KeDS(10);
				InDSCon(SV,a,sotrang);
            }
        }else if(k==27) break;
    }
}/*
void getLine(int c,int stt,vector<SinhVien> SV)
{
    textcolor(c);
    int i=stt%10;
    gotoxy(4,8+2*i); cout<<stt+1; gotoxy(14,8+2*i); cout<<SV[stt].MaLop; gotoxy(30,8+2*i); cout<<SV[stt].MSV;
    gotoxy(48,8+2*i); cout<<SV[stt].HoTen; gotoxy(77,8+2*i); cout<<SV[stt].Ngaysinh; gotoxy(94,8+2*i); cout<<SV[stt].diem;
}
void XoaSV(vector<SinhVien> &SV)
{
    int n=SV.size();
    int sotrang = (n%10==0&&n!=0)?n/10:n/10+1;
    int trang;
    int a=1,i=1;
    if(sotrang==1) KeDS(n);
    else KeDS(10);
    InDSCon(SV,a,sotrang);
    getLine(12,i-1,SV);
    while(1){

        int k=getch();
        if(k==77){
            a=a+10;
            if(a<n+1){
                system("cls");
                if(n-a<10) KeDS(n%10);
                else KeDS(10);
                InDSCon(SV,a,sotrang);
            }else{
                a=1;
                system("cls");
                KeDS(10);
                InDSCon(SV,a,sotrang);
            }
            trang=(a%10==0&&a!=0)?a/10:a/10+1;
            i=trang*10-9;
        }else if(k==75){
            a=a-10;
            i=i-10;
            if(a>=1){
                system("cls");
                KeDS(10);
                InDSCon(SV,a,sotrang);
            }else{
                for(int i=0;i<sotrang;i++){
					a=a+10;
				}
				system("cls");
				if(n-a<10) KeDS(n%10);
                else KeDS(10);
				InDSCon(SV,a,sotrang);
            }
            trang=(a%10==0&&a!=0)?a/10:a/10+1;
            i=trang*10-9;
        }else if(k==80){
            if(i<trang*10) i++;
            getLine(15,i-2,SV);
            getLine(12,i-1,SV);
        }else if(k==72){
            if(i>trang*10-9) i--;
            getLine(15,i+1,SV);
            getLine(12,i,SV);
        }else if(k==27) break;
    }
}*/
void ghifile(vector<SinhVien> SV)//ghi ra file text
{
    FILE *f;
    f=fopen("sinhvien.txt","wt");
    if(f==NULL){
        cout<<"Khong mo duoc file";
    }else{
        fprintf(f,"          ------------------------------------------------------------         \n");
        fprintf(f,"                              DANH SACH SINH VIEN                            \n");
        fprintf(f,"-------------------------------------------------------------------------------------------\n");
        fprintf(f,"| STT |   Ma Lop   |    MaSV    |      Ho va Ten      |  Ngay Sinh  | Diem TB |\n");
        fprintf(f,"-------------------------------------------------------------------------------------------\n");
        for(int i=0;i<SV.size();i++)
        {
            chuanhoachuoi(SV[i].HoTen);
            fprintf(f,"|%5.3d |%7s  | %8s  |%19s|%12s | %8.2f |\n\n",i+1,strupr(SV[i].MaLop),SV[i].MSV,SV[i].HoTen,SV[i].Ngaysinh,SV[i].diem);
        }
    }
    fclose(f);
}
void ReadFile(vector<SinhVien> &sv){
	SinhVien temp;
	ifstream f("Sinhvien.dat", ios::in | ios::binary);
	while(f.read(reinterpret_cast <char *>(&temp), sizeof(SinhVien))){
		sv.push_back(temp);
	}
	f.close();
}
void WriteFile(SinhVien sv){
	ofstream f("Sinhvien.dat", ios::app | ios::binary);
	f.write(reinterpret_cast<char*>(&sv), sizeof(SinhVien));
	f.close();
}
void SwapSV(SinhVien &sv1,SinhVien &sv2){
	SinhVien temp;
	temp=sv1;
	sv1=sv2;
	sv2=temp;
}
char* TachTen(char HoTen[])
{
    int i=strlen(HoTen)-1;
    while(HoTen[i]!=' ') i--;
    return &HoTen[i+1];
}
char* TachTenDem(SinhVien sv)
{
    char Hoten[50],dem[10],temp[10];
    strcpy(Hoten,sv.HoTen);
    int n=0;
    while(Hoten[n]!=' '){
        n++;
    }
    n++;
    int i=0;
    while(Hoten[n]!=' '){
        temp[i]=Hoten[n];
        i++;
        n++;
    }
    if(Hoten[n+1]!=' '){
        temp[0]=NULL;
    }else{
        temp[i]='\0';
        strcpy(dem,temp);
    }
    return &dem[0];
}
char* TachHo(char HoTen[])
{
	char Ho[50];
	strcpy(Ho,HoTen);
    int i=1;
    while(Ho[i]!=' ') i++;
    Ho[i]=NULL;
    return &Ho[0];
}
int NTN(SinhVien SV)
{
    XLNgay(&SV);
    int a=SV.nam*10000+SV.thang*100+SV.ngay;
    return a;
}
string DaoTen(char name[50])
{
        char ten[50];
    int j=0;
    int temp,n=strlen(name);
    for(int i=n-1;i>0;i--){
        if(name[i]==' ')
            break;
		ten[j]=name[i];
        j++;

    }
    ten[j]=NULL;
    strrev(ten);
    ten[j]=' ';
    int temp1 =j;
    for (int i=0;i <n - temp1-1;i++){
		if (name[i]!=' '){
    		ten[j++] = name[i];
    	}

	}
    string str(ten);
    return str;
}
void SelectionSort(vector<SinhVien> SV,int Opt)
{
    int n = SV.size();
    int min;
    char ten1[10],ten2[10];
    char dem1[10],dem2[10];
    char Ho1[10],Ho2[10];
    for(int i=0;i<n-1;i++)
    {
        min=i;
        for(int j=i+1;j<n;j++)
        {
            switch(Opt)
            {
                case 1:{
                    if(strcmp(SV[min].MaLop,SV[j].MaLop)>0)
                        min=j;
                }break;
                case 2:{
                    if(strcmp(SV[min].MSV,SV[j].MSV)>0)
                        min=j;
                }break;
                case 3:{
                    if(DaoTen(SV[min].HoTen).compare(DaoTen(SV[j].HoTen))>0)
                        min=j;
                }break;
                case 4:{
                	if(NTN(SV[min])<NTN(SV[j]))
                        min=j;
                }break;
                case 5:{
                     if(SV[min].diem<SV[j].diem)
                        min=j;
                }break;
            }
        }SwapSV(SV[i],SV[min]);
    }
    InDS(SV);
    getch();
    system("cls");
}
void InserSort(vector<SinhVien> SV,int Opt)
{
    int n1 = SV.size();
    char ten11[10],ten21[10];
    char dem11[10],dem21[10];
    char Ho11[10],Ho21[10];
    SinhVien temp;
    for(int i=1;i<n1;i++){
        XLNgay(&SV[i]);
        temp=SV[i];
        int j=i;
        switch(Opt){
            case 1:{
                while(j>0 && strcmp(SV[j-1].MaLop,temp.MaLop)>0){
                    SV[j]=SV[j-1];
                    j--;
                }
            }break;
            case 2:{
               while(j>0 && strcmp(SV[j-1].MSV,temp.MSV)>0){
                    SV[j]=SV[j-1];
                    j--;
                }
            }break;
            case 3:{
                strcpy(ten11,TachTen(temp.HoTen));
                strcpy(ten21,TachTen(SV[j-1].HoTen));
                while(j>0 && strcmp(ten21,ten11)>0){
                    SV[j]=SV[j-1];
                    j--;
                    strcpy(ten21,TachTen(SV[j-1].HoTen));
                }if(strcmp(ten21,ten11)==0){
                    strcpy(dem11,TachTenDem(temp));
                    strcpy(dem21,TachTenDem(SV[j-1]));
                    while(j>0 && strcmp(dem21,dem11)>0){
						SV[j]=SV[j-1];
                        j--;
                        strcpy(dem21,TachTenDem(SV[j-1]));
                    }if(strcmp(dem21,dem11)==0){
                        strcpy(Ho11,TachHo(temp.HoTen));
                        strcpy(Ho21,TachHo(SV[j-1].HoTen));
                        while(j>0 && strcmp(Ho21,Ho11)>0){
                            SV[j]=SV[j-1];
                            j--;
                            strcpy(Ho21,TachHo(SV[j-1].HoTen));
                        }
                    }
                }
            }break;
            case 4:{
                while(j>0 && NTN(SV[j-1])<NTN(temp)){
                    SV[j]=SV[j-1];
                    j--;
                }
            }break;
            case 5:{
                while(j>0 && SV[j-1].diem<temp.diem){
                    SV[j]=SV[j-1];
                    j--;
                }
            }break;

        }
    SV[j]=temp;
    }
    InDS(SV);
}
void BubbleSort(vector<SinhVien> SV,int Opt)
{
    int n2 = SV.size();
    char ten12[10],ten22[10];
    char dem12[10],dem22[10];
    char Ho12[10],Ho22[10];
    for(int i=0;i<n2-1;i++){
        for(int j=0;j<n2-i-1;j++){
            switch(Opt){
                case 1:{
                    if(strcmp(SV[j].MaLop,SV[j+1].MaLop)>0)
                        SwapSV(SV[j],SV[j+1]);
                }break;
                case 2:{
                    if(strcmp(SV[j].MSV,SV[j+1].MSV)>0){
                        SwapSV(SV[j],SV[j+1]);
                    }
                }break;
                case 3:{
                    if(DaoTen(SV[j].HoTen).compare(DaoTen(SV[j+1].HoTen))>0)
                        SwapSV(SV[j],SV[j+1]);
                }break;
                case 4:{
                    if(NTN(SV[j])<NTN(SV[j+1]))
                        SwapSV(SV[j],SV[j+1]);
                }break;
                case 5:{
                    if(SV[j].diem<SV[j+1].diem){
                        SwapSV(SV[j],SV[j+1]);
                    }
                }break;
            }
        }
    }
    InDS(SV);
}

void QuickSort(vector<SinhVien> &SV,int left,int right,int Opt)
{
    SinhVien Key=SV[(left+right)/2];
    int i=left,j=right;
    char NgayK[15];
    while(i < j){
        switch(Opt){
            case 1:{
                while(strcmp(SV[i].MaLop,Key.MaLop)<0){
                    i++;
                }
                while(strcmp(SV[j].MaLop,Key.MaLop)>0){
                    j--;
                }
            }break;
            case 2:{
                while(strcmp(SV[i].MSV,Key.MSV)<0){
                    i++;
                }
                while(strcmp(SV[j].MSV,Key.MSV)>0){
                    j--;
                }
            }break;
            case 3:{
                while(DaoTen(SV[i].HoTen).compare(DaoTen(Key.HoTen))<0){
                    i++;
                }
                while(DaoTen(SV[j].HoTen).compare(DaoTen(Key.HoTen))>0){
                    j--;
                }
            }break;
            case 4:{
                while(NTN(SV[i])>NTN(Key)){
                    i++;
                }
                while(NTN(SV[j])<NTN(Key)){
                    j--;
                }
            }break;
            case 5:{
                while(SV[i].diem>Key.diem){
                    i++;
                }
                while(SV[j].diem<Key.diem){
                    j--;
                }
            }break;
        }
        if(i<=j){
            SwapSV(SV[i],SV[j]);
            i++;
            j--;
        }
    }
    if(left<j) QuickSort(SV,left,j,Opt);
    if(i<right) QuickSort(SV,i,right,Opt);
}
int strInStr(char* cha,char* con,int Opt)
{
    if(Opt==3){
        strlwr(cha);
        strlwr(con);
    }
    char* tmp;
    if (tmp = strstr(cha,con))
    {
        return (tmp-cha);
    }
    else
    {
        return -1;
    }
}
void InKhoa(char A[],char Key[],int Opt)
{
    int n=strlen(A);
    int m=strlen(Key);
    int a=strInStr(A,Key,Opt);
    if(Opt==3) chuanhoachuoi(A);
    for(int i=0;i<n;i++){
		if(i<a||i>=a+m){
			cout<<A[i];
		}else{
			textcolor(12);
			cout<<A[i];
			textcolor(15);
		}
	}
}
void InTimKiem(vector<SinhVien> SV,char Key[],int Opt)
{
    int n=SV.size();
    if(n==0){
        textcolor(1);
        gotoxy(41,5);textcolor(28);
        cout << "KHONG TIM THAY SINH VIEN NAO !!!";
    }else{
        textcolor(1);
        gotoxy(41,1);textcolor(28);
        cout << "--------TIM THAY "<< SV.size() <<" SINH VIEN--------";gotoxy(5,9);textcolor(29);
        KeDS(n);
        textcolor(15);
        switch(Opt)
        {
            case 1:{
                for (int i = 0; i < SV.size(); i++)
                {
                    gotoxy(4,8+2*i);textcolor(15);cout<<i+1;
                    gotoxy(14,8+2*i);
                    InKhoa(SV[i].MaLop,Key,Opt);
                    gotoxy(30,8+2*i); cout<<SV[i].MSV;gotoxy(48,8+2*i); cout<<SV[i].HoTen;
                    gotoxy(77,8+2*i); cout<<SV[i].Ngaysinh; gotoxy(94,8+2*i); cout<<SV[i].diem;

                }
            }break;
            case 2:{
                for (int i = 0; i < SV.size(); i++)
                {
                    gotoxy(4,8+2*i); cout<<i+1; gotoxy(14,8+2*i); cout<<SV[i].MaLop;
                    gotoxy(30,8+2*i);
                    InKhoa(SV[i].MSV,Key,Opt);
                    gotoxy(48,8+2*i); cout<<SV[i].HoTen;
                    gotoxy(77,8+2*i); cout<<SV[i].Ngaysinh; gotoxy(94,8+2*i); cout<<SV[i].diem;
                }
            }break;
            case 3:{
                for (int i = 0; i < SV.size(); i++)
                {
                    gotoxy(4,8+2*i); cout<<i+1; gotoxy(14,8+2*i); cout<<SV[i].MaLop;
                    gotoxy(30,8+2*i); cout<<SV[i].MSV;gotoxy(48,8+2*i);
                    InKhoa(SV[i].HoTen,Key,Opt);
                    gotoxy(77,8+2*i); cout<<SV[i].Ngaysinh; gotoxy(94,8+2*i); cout<<SV[i].diem;
                }
            }break;
            case 4:{
                for (int i = 0; i < SV.size(); i++)
                {
                    gotoxy(4,8+2*i); cout<<i+1; gotoxy(14,8+2*i); cout<<SV[i].MaLop;
                    gotoxy(30,8+2*i); cout<<SV[i].MSV;gotoxy(48,8+2*i); cout<<SV[i].HoTen;
                    gotoxy(77,8+2*i);
                    InKhoa(SV[i].Ngaysinh,Key,Opt);
                    gotoxy(94,8+2*i); cout<<SV[i].diem;
                }
            }break;
            case 5:{
                for (int i = 0; i < SV.size(); i++)
                {
                    gotoxy(4,8+2*i); cout<<i+1; gotoxy(14,8+2*i); cout<<SV[i].MaLop;
                    gotoxy(30,8+2*i); cout<<SV[i].MSV;gotoxy(48,8+2*i); cout<<SV[i].HoTen;
                    gotoxy(77,8+2*i); cout<<SV[i].Ngaysinh;
                    textcolor(12);
                    gotoxy(94,8+2*i); cout<<SV[i].diem;
                }
            }break;
        }
    }
}
void TimKiemTuanTu(vector<SinhVien> SV,int Opt)
{
    char Key[20];
    float key;
    switch(Opt){
        case 1:{
            gotoxy(22,9);
            fflush(stdin);
            gets(Key);
        }break;
        case 2:{
            gotoxy(22,11);
            fflush(stdin);
            gets(Key);
        }break;
        case 3:{
            gotoxy(22,13);
            fflush(stdin);
            gets(Key);
        }break;
        case 4:{
            gotoxy(22,15);
            fflush(stdin);
            gets(Key);
        }break;
        case 5:{
            gotoxy(22,17);
            cin>>key;
        }break;
    }
    vector<SinhVien> temp;
    for(int i=0;i<SV.size();i++){
        switch(Opt){
            case 1:{
                if(strstr(SV[i].MaLop,Key)!=NULL){
                    temp.push_back(SV[i]);
                }
            }break;
            case 2:{
                if(strstr(SV[i].MSV,Key)!=NULL){
                    temp.push_back(SV[i]);
                }
            }break;
            case 3:{
                strlwr(Key);
                if(strstr(strlwr(SV[i].HoTen),Key)!=NULL){
                    chuanhoachuoi(SV[i].HoTen);
                    temp.push_back(SV[i]);
                }
            }break;
            case 4:{
                if(strstr(SV[i].Ngaysinh,Key)!=NULL){
                    temp.push_back(SV[i]);
                }
            }break;
            case 5:{
                if(SV[i].diem==key){
                    temp.push_back(SV[i]);
                }
            }break;
        }
    }
    system("cls");
    InTimKiem(temp,Key,Opt);
}
void TenLop(SinhVien &sv)
{
    int n=sizeof(sv.HoTen)-1;
    while(sv.HoTen[n]==' '){
        sv.HoTen[n]=NULL;
    }
}
struct Lop
{
    char Ten[10];
    int XS=0,G=0,K=0,TB=0,Y=0,TVien=0;
    double xs=0,g=0,k=0,tb=0,y=0;
};
void ThongKe(vector<SinhVien> Temp,Lop &lp)
{
    int n=Temp.size();
    QuickSort(Temp,0,n-1,5);
    int XS,G,K,TB,Y;
    for(int i=0;i<n;i++)
    {
       if(Temp[i].diem>=3.6){
            lp.XS++;
       }else if(Temp[i].diem<3.6 && Temp[i].diem>=3.2){
            lp.G++;
       }else if(Temp[i].diem<3.2 && Temp[i].diem>=2.5){
            lp.K++;

       }else if(Temp[i].diem<2.5 && Temp[i].diem>=2){
            lp.TB++;

       }else if(Temp[i].diem<2 && Temp[i].diem>=0){
            lp.Y++;

       }
    }
    lp.xs=(lp.XS/n)*100;
    lp.g=(lp.G/n)*100;
    lp.k=(lp.K/n)*100;
    lp.tb=(lp.TB/n)*100;
    lp.y=(lp.Y/n)*100;
    lp.TVien=n;
}
void KeBangThongKe(int n,int Opt)
{
    switch(Opt){
        case 1:{
            textcolor(2);
            string a="Ma lop"; string b="Ten Lop"; string c="So Sinh Vien"; string d="Tong";
            gotoxy(15,3); cout<<char(218); kehang(16); cout<<char(194); kehang(34); cout<<char(194); kehang(25); cout<<char(191)<<endl;
            gotoxy(15,4); cout<<char(179); ToMau(21,4,a,12,2); gotoxy(32,4); cout<<char(179); ToMau(45,4,b,12,2);
            gotoxy(67,4); cout<<char(179); ToMau(75,4,c,12,2); gotoxy(93,4); cout<<char(179);
            gotoxy(15,5); cout<<char(195);kehang(77); gotoxy(32,5); cout<<char(197); gotoxy(67,5); cout<<char(197); gotoxy(93,5); cout<<char(180);
            for(int i=0;i<n;i++){
                gotoxy(15,7+2*i);cout << char(195); kehang(16); cout<<char(197); kehang(34); cout<<char(197); kehang(25); cout<<char(180);
            }
            for(int i=0;i<2*n+1;i=i+2){
                gotoxy(15,6+i); cout<<char(179); gotoxy(32,6+i); cout<<char(179); gotoxy(67,6+i); cout<<char(179); gotoxy(93,6+i); cout<<char(179);
            }
            gotoxy(15,2*n+7); cout<<char(195); kehang(77); gotoxy(32,2*n+7); cout<<char(193); gotoxy(67,2*n+7); cout<<char(197); gotoxy(93,2*n+7); cout<<char(180);
            gotoxy(15,2*n+8); cout<<char(179); ToMau(40,2*n+8,d,12,2); gotoxy(67,2*n+8); cout<<char(179); gotoxy(93,2*n+8); cout<<char(179);
            gotoxy(15,2*n+9); cout<<char(192); kehang(77); gotoxy(67,2*n+9); cout<<char(193); gotoxy(93,2*n+9); cout<<char(217);
            textcolor(15);
        }break;
        case 2:{
            textcolor(2);
            string a="Ma Lop"; string b="Xuat sac"; string c="Gioi"; string d="Kha"; string e="Trung binh";
            string f="Yeu"; string g="Tong"; string k="SL"; string h="%";
            gotoxy(10,3); cout<<char(218); kehang(12); cout<<char(194); kehang(15); cout<<char(194); kehang(15); cout<<char(194);
            kehang(15); cout<<char(194); kehang(15); cout<<char(194); kehang(15); cout<<char(191)<<endl;
            gotoxy(10,4); cout<<char(179); ToMau(14,5,a,12,2);
            gotoxy(10,5); cout<<char(179); gotoxy(23,4); cout<<char(179); ToMau(28,4,b,12,2); gotoxy(39,4); cout<<char(179);
            ToMau(46,4,c,12,2); gotoxy(55,4); cout<<char(179); ToMau(62,4,d,12,2); gotoxy(71,4); cout<<char(179);
            ToMau(74,4,e,12,2); gotoxy(87,4); cout<<char(179); ToMau(94,4,f,12,2); gotoxy(103,4); cout<<char(179);
            gotoxy(23,5); cout<<char(195); kehang(7); cout<<char(194); kehang(7); cout<<char(197); kehang(7); cout<<char(194); kehang(7); cout<<char(197);
            kehang(7); cout<<char(194); kehang(7); cout<<char(197); kehang(7); cout<<char(194); kehang(7); cout<<char(197); kehang(7); cout<<char(194);
            kehang(7); cout<<char(180);
            ToMau(27,6,k,12,2); ToMau(43,6,k,12,2); ToMau(59,6,k,12,2); ToMau(75,6,k,12,2); ToMau(91,6,k,12,2);
            ToMau(35,6,h,12,2); ToMau(51,6,h,12,2); ToMau(67,6,h,12,2); ToMau(83,6,h,12,2); ToMau(99,6,h,12,2);
            for(int i=0;i<n;i++)//n+1 la so hang
            {
                gotoxy(10,2*i+7); cout<<char(195); kehang(12); gotoxy(23,2*i+7); cout<<char(197); kehang(7); cout<<char(197); kehang(7); cout<<char(197);
                kehang(7); cout<<char(197); kehang(7); cout<<char(197); kehang(7); cout<<char(197); kehang(7); cout<<char(197);
                kehang(7); cout<<char(197); kehang(7); cout<<char(197); kehang(7); cout<<char(197); kehang(7); cout<<char(180);
            }
            for(int i=0;i<2*n+1;i=i+2)
            {
                gotoxy(10,6+i); cout<<char(179); gotoxy(23,6+i); cout<<char(179); gotoxy(31,6+i); cout<<char(179); gotoxy(39,6+i); cout<<char(179);
                gotoxy(47,6+i); cout<<char(179); gotoxy(55,6+i); cout<<char(179); gotoxy(63,6+i); cout<<char(179); gotoxy(71,6+i); cout<<char(179);
                gotoxy(79,6+i); cout<<char(179); gotoxy(87,6+i); cout<<char(179); gotoxy(95,6+i); cout<<char(179); gotoxy(103,6+i); cout<<char(179);
            }
            gotoxy(10,2*n+7); cout<<char(192); kehang(12); cout<<char(193); kehang(7); cout<<char(193); kehang(7); cout<<char(193); kehang(7);
            cout<<char(193); kehang(7); cout<<char(193); kehang(7); cout<<char(193); kehang(7); cout<<char(193); kehang(7); cout<<char(193); kehang(7);
            cout<<char(193); kehang(7); cout<<char(193); kehang(7); cout<<char(217);
            ToMau(14,2*n+6,g,12,2);
            textcolor(15);
        }break;
    }
}
void InThongKe(vector<Lop> LP,int Opt)
{
    int n=LP.size();
    switch(Opt){
        case 1:{
            textcolor(2);
            KeBangThongKe(n-1,Opt);
            textcolor(12);
            gotoxy(36,0); cout<<"********************************************";
            gotoxy(40,1); cout<<"THONG KE DU LIEU SINH VIEN THEO LOP";
            textcolor(15);
            int n1=0;
            for(int i=0;i<n;i++){
                gotoxy(19,6+2*i); cout<<LP[i].Ten;
                gotoxy(46,6+2*i); cout<<LP[i].Ten;
                gotoxy(81,6+2*i); cout<<LP[i].TVien;
                n1=n1+LP[i].TVien;
            }
            gotoxy(81,6+2*n); cout<<n1;
        }break;
        case 2:{
            KeBangThongKe(n+1,Opt);
            textcolor(12);
            gotoxy(36,0); cout<<"********************************************";
            gotoxy(40,1); cout<<"THONG KE DU LIEU SINH VIEN THEO LOP";
            textcolor(15);
            int XS=0,G=0,K=0,TB=0,Y=0;
            double xs,g,k,tb,y;
            for(int i=0;i<n;i++){
                gotoxy(14,2*i+8); cout<<LP[i].Ten;
                gotoxy(27,2*i+8); cout<<LP[i].XS; XS=LP[i].XS+XS;
                gotoxy(34,2*i+8); cout<<LP[i].xs;
                gotoxy(43,2*i+8); cout<<LP[i].G; G=LP[i].G+G;
                gotoxy(50,2*i+8); cout<<LP[i].g;
                gotoxy(59,2*i+8); cout<<LP[i].K; K=LP[i].K+K;
                gotoxy(66,2*i+8); cout<<LP[i].k;
                gotoxy(75,2*i+8); cout<<LP[i].TB; TB=LP[i].TB+TB;
                gotoxy(82,2*i+8); cout<<LP[i].tb;
                gotoxy(91,2*i+8); cout<<LP[i].Y; Y=LP[i].Y+Y;
                gotoxy(98,2*i+8); cout<<LP[i].y;
                if(i==n-1){
                    int N=XS+G+K+TB+Y;
                    xs=static_cast<float>(XS*100)/N; g=static_cast<float>(G*100)/N; k=static_cast<float>(K*100)/N; tb=static_cast<float>(TB*100)/N; y=static_cast<float>(Y*100)/N;
                    gotoxy(27,2*i+10); cout<<XS; gotoxy(34,2*i+10); cout<<setprecision(3); cout<<xs;
                    gotoxy(43,2*i+10); cout<<G; gotoxy(50,2*i+10); cout<<setprecision(3); cout<<g;
                    gotoxy(59,2*i+10); cout<<K; gotoxy(66,2*i+10); cout<<setprecision(3); cout<<k;
                    gotoxy(75,2*i+10); cout<<TB; gotoxy(82,2*i+10); cout<<setprecision(3); cout<<tb;
                    gotoxy(91,2*i+10); cout<<Y; gotoxy(98,2*i+10); cout<<setprecision(3); cout<<y;
                }
            }
        }break;
    }
}
void ChiaThongKe(vector<SinhVien> SV,int Opt)
{
    vector<SinhVien> Temp;
    QuickSort(SV,0,SV.size()-1,1);
    Temp.push_back(SV[0]);
    vector<Lop> LP;
    for(int i=1;i<=SV.size();i++){
        if(strcmp(SV[i].MaLop,SV[i-1].MaLop)==0){
                Temp.push_back(SV[i]);
        }else{
            Lop temp1;
            strcpy(temp1.Ten,SV[i-1].MaLop);
            ThongKe(Temp,temp1);
            LP.push_back(temp1);
            Temp.clear();
            Temp.push_back(SV[i]);
        }
    }
    system("cls");
    switch(Opt){
        case 1:{
            InThongKe(LP,Opt);
        }break;
        case 2:{
            InThongKe(LP,Opt);
        }break;
    }
}

int main()
{
    system("chcp 437");//mã ký tự kiểu mỹ
    system("cls");
    Nocursortype();
    int Opt=1;
    vector<SinhVien> ListSV;
    ReadFile(ListSV);
    do{
        textcolor(2);
        Intieude();
        again1:
            InMang(MenuChinh,6,Opt);
        do{
            Key=getch();
        }while(!(Key==13||Key==27||Key==72||Key==80||Key==75||Key==77));//13:Enter/27:Esc/72:lên/80:xuống/75:trái/77:phải
        if(Key==80){
            Opt++;
            if(Opt>6)
                Opt=1;
        }
        if(Key==72){
            Opt--;
            if(Opt<1)
                Opt=6;
        }
        if (Key==27){
            system("cls");
            goto again1;
        }
    }while(!(Key==13||Key==77));

    switch(Opt){
        case 1:{
            SinhVien sv1;
        	int Opt1=0;
            system("cls");
            gotoxy(42,5);
            textcolor(13);
            cout<<"NHAP DU LIEU SINH VIEN MOI"<<endl;
            do{
                textcolor(2);
                Intieude();
                InMang(Muc1_Nhap,5,Opt1);
				sv1=NhapHoSo();
				ListSV.push_back(sv1);
                WriteFile(sv1);
                do{
                    Key=getch();
                }while(!(Key==13||Key==27||Key==72||Key==80||Key==75||Key==77));
                if(Key==80){
                    Opt1++;
                    if(Opt1>5)
                        Opt1=1;
                }
                if(Key==72){
                    Opt1--;
                    if(Opt1<1)
                        Opt1=5;
                }
                if (Key==27){
                    system("cls");
                    goto again1;
                }
            }while(!(Key==13||Key==77));
            system("cls");
			goto again1;
        }
        case 2:{
        	system("cls");
        	InDS(ListSV);
        	getch();
        	system("cls");
        	goto again1;
        }break;
        case 3:{
            int Opt3=1;
            system("cls");
            do{
                textcolor(2);
                Intieude();
                again3:
                	gotoxy(45,4);
                	textcolor(13);
            		cout<<"SAP XEP SINH VIEN"<<endl;
            		gotoxy(1,6);
           			cout<<"THUAT TOAN SAP XEP"<<endl;
                	InMang(Muc3_Sapxep,4,Opt3);
                do{
                    Key=getch();
                }while(!(Key==13||Key==27||Key==72||Key==80||Key==75||Key==77));
                if(Key==80){
                    Opt3++;
                    if(Opt3>4)
                        Opt3=1;
                }
                if(Key==72){
                    Opt3--;
                    if(Opt3<1)
                        Opt3=4;
                }
                if (Key==27){
                    system("cls");
                    goto again1;
                }
            }while(!(Key==13||Key==77));
            if(Opt3<5){
                int Opt3_1=1;
            	system("cls");
	            do{
	                textcolor(2);
	                Intieude();
	                gotoxy(45,4);
	                textcolor(13);
           			cout<<"SAP XEP THEO KHOA"<<endl;
	                InMang(muc4_con,5,Opt3_1);
	                do{
	                    Key=getch();
	                }while(!(Key==13||Key==27||Key==72||Key==80||Key==75||Key==77));
	                if(Key==80){
	                    Opt3_1++;
	                    if(Opt3_1>5)
                            Opt3_1=1;
	                }
	                if(Key==72){
	                    Opt3_1--;
	                    if(Opt3_1<1)
                            Opt3_1=5;
	                }
	                if (Key==27){
	                    system("cls");
	                    goto again3;
	                }
	            }while(!(Key==13||Key==77));
                    system("cls");
                    switch(Opt3){
                        case 1:{
                            SelectionSort(ListSV,Opt3_1);
                            goto again1;
                        }break;
                        case 2:{
                            InserSort(ListSV,Opt3_1);
                            getch();
                            system("cls");
                            goto again1;
                        }break;
                        case 3:{
                            QuickSort(ListSV,0,ListSV.size()-1,Opt3_1);
                            InDS(ListSV);
                            getch();
                            system("cls");
                            goto again1;
                        }break;
                        case 4:{
                            BubbleSort(ListSV,Opt3_1);
                            getch();
                            system("cls");
                            goto again1;
                        }break;
                    }
			}
			break;
        }
        case 4:{
            int Opt4=1;
            system("cls");
            do{
                textcolor(2);
                Intieude();
                again4:
                	gotoxy(45,4);
                	textcolor(13);
            		cout<<"TIM KIEM SINH VIEN"<<endl;
            		gotoxy(1,6);
           			cout<<"THUAT TOAN TIM KIEM"<<endl;
                	InMang(Muc4_TimKiem,2,Opt4);
                do{
                    Key=getch();
                }while(!(Key==13||Key==27||Key==72||Key==80||Key==75||Key==77));
                if(Key==80){
                    Opt4++;
                    if(Opt4>1)
                        Opt4=1;
                }
                if(Key==72){
                    Opt4--;
                    if(Opt4<1)
                        Opt4=1;
                }
                if (Key==27){
                    system("cls");
                    goto again1;
                }
            }while(!(Key==13||Key==77));
            if(Opt4==1||Opt4==2){
            	int Opt4_1=1;
            	system("cls");
	            do{
	                textcolor(2);
	                Intieude();
	                gotoxy(45,4);
	                textcolor(13);
           			cout<<"TIM KIEM THEO KHOA"<<endl;
	                InMang(muc4_con,5,Opt4_1);
	                do{
	                    Key=getch();
	                }while(!(Key==13||Key==27||Key==72||Key==80||Key==75||Key==77));
	                if(Key==80){
	                    Opt4_1++;
	                    if(Opt4_1>5)
                            Opt4_1=1;
	                }
	                if(Key==72){
	                    Opt4_1--;
	                    if(Opt4_1<1)
                            Opt4_1=5;
	                }
	                if (Key==27){
	                    system("cls");
	                    goto again4;
	                }
	            }while(!(Key==13||Key==77));
                    switch(Opt4){
                        case 1:{
                            Cursortype();
                            TimKiemTuanTu(ListSV,Opt4_1);
                            Nocursortype();
                            getch();
                            system("cls");
                            goto again1;
                        }break;
                    }
			}
			break;
        }
        case 5:{
			int Opt5=1;
            system("cls");
            do{
                textcolor(2);
                Intieude();
                gotoxy(45,4);
            	textcolor(13);
        		cout<<"THONG KE SINH VIEN"<<endl;
                InMang(Muc5_Thongke,2,Opt5);
                do{
                    Key=getch();
                }while(!(Key==13||Key==27||Key==72||Key==80||Key==75||Key==77));
                if(Key==80){
                    Opt5++;
                    if(Opt5>2)
                        Opt5=1;
                }
                if(Key==72){
                    Opt5--;
                    if(Opt5<1)
                        Opt5=2;
                }
                if (Key==27){
                    system("cls");
                    goto again1;
                }
			}while(!(Key==13||Key==77));
                system("cls");
                ChiaThongKe(ListSV,Opt5);
                getch();
                system("cls");
                goto again1;
		}break;
		case 6:{
		    ghifile(ListSV);
			exit(0);
		}
	}
	return 0;
}
