import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Randevu } from './models/randevu';
import { RandevuService } from './services/randevu.service';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FormsModule, DatePipe],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  randevular : Randevu[] = [];
  yeniKayit : any = { durum : "Bekliyor" };
  doktorlar : any[] = [];

  constructor(private randevuService : RandevuService) { }

  ngOnInit(): void {
    this.randevuService.getRandevular().subscribe(data => { this.randevular = data });

    this.randevuService.getDoktorlar().subscribe(data => { this.doktorlar = data });
  }

  getDoktor(id: number) {
    return this.doktorlar.find(d => d.doktorId === id);
  }

  sadeceRakam(event: any) {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      event.preventDefault();
    }
  }

  kaydet() {
    if (!this.yeniKayit.hastaTC || !this.yeniKayit.hastaAdSoyad || !this.yeniKayit.doktorId) {
      alert("Lütfen TC, Ad Soyad ve Doktor alanlarını doldurunuz!");
      return;
    }

    if (this.yeniKayit.hastaTC && this.yeniKayit.hastaTC.length !== 11) {
      alert("TC Kimlik numarası tam 11 haneli olmalıdır!");
      return;
    }

    if (!this.yeniKayit.tarihSaat) {
      alert("Lütfen geçerli bir tarih seçiniz!");
      return;
    }

    const secilenTarih = new Date(this.yeniKayit.tarihSaat);
    const suAn = new Date();
    if (secilenTarih < suAn) {
      alert("Geçmiş bir tarihe randevu oluşturamazsınız!");
      return;
    }

    this.randevuService.ekleRandevu(this.yeniKayit).subscribe(() => {
      this.ngOnInit(); // Tabloyu yenile
      this.yeniKayit = { durum: 'Bekliyor' };
    });
  }

  iptalEt(id : number){
    this.randevuService.iptalRandevu(id).subscribe(() => { this.ngOnInit(); });
  }

  ertele(id : number, yeniTarih : string){
    if(!yeniTarih){
      alert("Lütfen önce yeni bir tarih seçin!");
      return;
    }

    this.randevuService.ertele(id, yeniTarih).subscribe( () => {
      this.ngOnInit();
    });
  }
}
