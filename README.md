# Poliklinik Randevu Sistemi 🏥

Bu proje, bir polikliniğin günlük randevu işleyişini yönetmek amacıyla geliştirilmiş Full-Stack (Uçtan Uca) bir otomasyon sistemidir. 

## 🛠️ Kullanılan Teknolojiler
* **Backend:** C# .NET 8 (ASP.NET Core Web API)
* **Veritabanı:** Microsoft SQL Server & Entity Framework Core (Code-First)
* **Frontend:** Angular & TypeScript
* **Tasarım:** Saf HTML/SCSS (Modern UI)

## 🌟 Öne Çıkan Özellikler
* **Dinamik Doktor Seçimi:** Veritabanındaki doktorların sisteme otomatik entegrasyonu.
* **Akıllı Durum Kontrolü:** Saati geçen "Bekliyor" durumundaki randevuların otomatik olarak "Tedavi Yapıldı" statüsüne geçmesi.
* **Randevu Yönetimi:** Yeni randevu oluşturma, iptal etme ve ileri bir tarihe erteleme işlemleri.
* **Veri Güvenliği:** 11 haneli TC Kimlik kontrolü ve geçmiş tarihe randevu alınmasını engelleyen algoritma.

---

## ⚠️ Kurulum ve Çalıştırma (ÖNEMLİ)

Projeyi kendi bilgisayarınızda çalıştırmadan önce aşağıdaki iki konfigürasyonu kendi sisteminize göre ayarlamanız gerekmektedir:

### 1. Veritabanı Bağlantısı (Connection String)
Projede lokal (yerel) bir SQL Server kullanılmıştır. Projeyi ayağa kaldırmadan önce `Backend` klasörü altındaki **`appsettings.json`** dosyasını açın ve `DefaultConnection` kısmını kendi SQL Server isminize (Server Name) göre güncelleyin.
Ardından veritabanını oluşturmak için Package Manager Console üzerinden şu komutu çalıştırın:
`Update-Database`

### 2. Sistemi Otomatik Başlatma (baslat.bat)
Projenin ana dizininde bulunan `baslat.bat` dosyası, hem Backend hem de Frontend projelerini tek tıkla ayağa kaldırmak için yazılmış bir makrodur. Ancak bu dosya içindeki klasör yolları (örn: `cd Backend/...`) geliştirme ortamına göre ayarlanmıştır.
Kendi bilgisayarınızda hata alırsanız:
* `.bat` dosyasına sağ tıklayıp "Düzenle" diyerek içindeki klasör yollarını kendi yapınıza göre güncelleyebilir,
* Veya projeleri kendi klasörlerinde terminal açarak sırasıyla `dotnet run` ve `ng serve --open` komutlarıyla manuel olarak başlatabilirsiniz.

---

## 👨‍💻 Geliştirici
**İbrahim Efe Kargın**  
*Yıldız Teknik Üniversitesi - Bilgisayar Mühendisliği*
