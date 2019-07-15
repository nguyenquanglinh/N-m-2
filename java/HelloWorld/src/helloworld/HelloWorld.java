/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package helloworld;

import java.io.IOException;
import java.util.List;
import java.util.Scanner;
import jdk.nashorn.internal.parser.TokenType;
/**
 *
 * @author thang
 */
public class HelloWorld {

    /**
     * @param args the command line arguments
     * @throws java.io.IOException
     */
    public static void main(String[] args) throws IOException {
        // TODO code application logic here
        Scanner scanner = new Scanner(System.in);
        FileString f=new FileString("C:\\Users\\thang\\Desktop\\");
        f.WriteFile("abc.txt", "bai nayf quas kho");
        List<String> line=f.OpenFile("main.txt");
        System.out.println(line);
        BoiSo boiso=new BoiSo(7);
        TongDayN tong=new TongDayN(10);
        System.out.println(tong.TinhTong());
        List<Integer>listBs= boiso.LayDsBoiSoTu(1, 100);
        for (int i = 0; i < listBs.size(); i++) {
            System.out.println(listBs.get(i));
        }
        System.out.println(boiso);
        System.out.println("tong boi so cua "+boiso.n+" tu 1->100 = "+boiso.TongBoiSO(1, 100));

                
        System.out.print("Nhap a ");
        int a=scanner.nextInt(); 
        System.out.print("Nhap b ");
        int b=scanner.nextInt();
        System.out.print("Nhap c ");
        int c=scanner.nextInt();
        float dental=(float) (Math.pow(b,2)-4*a*c);
        if (dental<0)
            System.out.println("pt vo nghiem");
        else if(dental==0)
            System.out.println("x1=x2= "+-b/2*a);
        else
        {
            System.out.println("x1= "+(-b-Math.sqrt(dental))/2*a);
            System.out.println("x2= "+(-b+Math.sqrt(dental))/2*a);
        }
        
    }
    
    
    
    
}

