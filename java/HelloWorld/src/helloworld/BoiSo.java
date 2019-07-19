/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package helloworld;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author thang
 */
public class BoiSo {

    public  BoiSo(int x){
        this.n=x;
}
   final int n;
    private boolean KiemTraBoiSo(int x){
        if (x<n)
            return false;
        else if(x%n==0)
            return true;
        return false;
    }
    public  List<Integer> LayDsBoiSoTu(int start,int end){
        List<Integer> listBs =new ArrayList<>();
        for (int i = start; i < end; i++) {
            if(KiemTraBoiSo(i))
                listBs.add(i);
        }
        return listBs;
    }
    public int TongBoiSO(int start,int end){
        int tong=0;
        List<Integer> list=LayDsBoiSoTu(start, end);
        for (int i = 0; i < list.size(); i++) {
            tong+=list.get(i);
        }
        return tong;
    }

    public String toString() { 
        return String.format( n+ " + i" ); 
    } 
}
