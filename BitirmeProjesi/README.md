# Teleperformance .Net Bootcamp Bitirme Proesi

Bu proje Patika.dev & Teleperformance ortaklığıyla düzenlenen bootcamp bitirme projesidir.

### Kullanılan Teknolojiler:
:heavy_check_mark: .Net 6.0 frameworkü ile Asp.Net Core Web API ve ConsoleApp kullanıldı.<br>
:heavy_check_mark: Onion Architecture kullanıldı.<br>
:heavy_check_mark: Postman ile API test edildi.<br>
:heavy_check_mark: API'nin dışardan kullanılabilmesi için token(JWT) bazlı bir yapı geliştirildi.<br>
:heavy_check_mark: Event fırlatma işlemi için RabbitMQ kullanıldı.<br>
:heavy_check_mark: Veritabanı işlemleri için EntityFrameworkCore, MSSQL ve MongoDb kullanıldı.<br>
:heavy_check_mark: Identity ve Authenticate kullanıldı. <br>
:heavy_check_mark: Projede Unit ve Entegrasyon testi yazıldı.<br>
:heavy_check_mark: InMemoryCache kullanıldı.<br>

## Proje İçeriği:
- Özetle kullanıcıların almayı planladıkları ürünleri kaydedip takibini yapabilecekleri bir Web API.
- Kullanıcı kaydı, girişi ve doğrulama işlemleri yapılabilmekte.
- Kategori, başlık, ürünler(isim,miktar,tip), oluşturulma tarihi, tamamlanma tarihi ve tamamlanma durumu parametreleri Shopping List'i oluşturuyor.
- Get, Post, Delete, Patch, Put gibi HTTP metodları ile listeler ve ürünler için işlemler yapılabilmekte.

## Proje Kullanımı ve Kurulumu

- Projeyi indirmek için :
```
    git clone https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi.git
```

- Veritabanı oluşturmak için package manager konsolunda default project kısmında `BitirmeProjesi.Persistence` seçili olmalıdır. Ardından :
```c
    update-database
```

- Appsettings.json içindeki verilerin kendi bilgisayarınıza göre dizayn edilmesi lazım
```c
    {
    "ConnectionStrings": {
        "Default": "SQL Server Connection String;"
    },
    "MongoConnectionStrings": {
        "ConnectionString": "MongoDb Connection String",
        "DatabaseName": "Veritabanı adı",
        "ShoppingListName": "ShoppingLists"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "JWT": {
        "Audience": "http://google.com",
        "Issuer": "http://google.com",
        "Token": "This is my supper secret key for jwt"
    }
}
```

- Kullanımı için projemizi derledikten sonra çalıştırıyoruz.

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/swagger1.png"/>

- Controller metodları

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/swagger2.png"/>

- Controller metodları

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/postman1.png"/>

- Kayıtlı kullanıcı girişi 

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/postman2.png"/>

- Giriş yaptıktan sonra doğrulama yapılması ve token verilmesi

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/postman3.png"/>

- Tokenin type'ını Bearer Token olarak seçtikten sonra ilgili yere yapıştırılması

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/postman4.png"/>

- Shopping Listimizi hazırlamak için url query kısmına categoryname ve title kısmını girdikten sonra body tarafında shopping listingin oluşturulması

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/postman5.png"/>

- Get yaptığımızda dönen response

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/postman6.png"/>

- Get yaptığımızda dönen response

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/postman7.png"/>

- Listenin tamamlanması için Patch metoduyla iscompleted değerinin 1 verilmesi

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/rabbitmq.png"/>

- Patch metoduyla eventin yakalanması ve RabbitMQ tarafından görülmesi

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/rabbitmq2.png"/>

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/mongo.png"/>

- Tamamlanan listenin MongoDb tarafından kayıt alınması ve gösterilmesi

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/EmrullahYilmazBitirmeProjesi/blob/master/Media/postman8.png"/>

- Doğrulamayı test etmek için token type'ını kapattıktan sonra sistemin kullanıcıyı Unauthorized etmesi




	