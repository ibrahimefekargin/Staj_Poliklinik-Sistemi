import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Randevu } from '../models/randevu';

@Injectable({
    providedIn : 'root'
})
export class RandevuService {

    apiUrl : string = 'http://localhost:5127/api/Randevular';

    constructor(private httpClient : HttpClient){ }

    getRandevular(){

        return this.httpClient.get<Randevu[]>(this.apiUrl);
    }

    ekleRandevu(yeniRandevu : Randevu){
        return this.httpClient.post(this.apiUrl, yeniRandevu);
    }

    iptalRandevu(id : number){
        return this.httpClient.put(`${this.apiUrl}/${id}/iptal`, {});
    }

    ertele(id : number, yeniTarih : string){
        return this.httpClient.put(`${this.apiUrl}/${id}/ertele`, JSON.stringify(yeniTarih), {
            headers: { 'Content-Type': 'application/json' }
        });
    }

    getDoktorlar() {
        return this.httpClient.get<any[]>(this.apiUrl + '/doktorlar');
    }
}
