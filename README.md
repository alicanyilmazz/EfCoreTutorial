# EfCoreTutorial

![image](https://user-images.githubusercontent.com/49749125/164887227-827a2123-7568-4030-8762-a1893bef77c9.png)
![image](https://user-images.githubusercontent.com/49749125/164887242-a41ececf-6fcb-4540-9e83-3d4708edc7eb.png)
![image](https://user-images.githubusercontent.com/49749125/164887249-d5524820-a7af-4a21-b697-b28f5f78ce86.png)
![image](https://user-images.githubusercontent.com/49749125/164887259-078f2b2e-b7c8-43d3-b7af-5624dfa848fe.png)
![image](https://user-images.githubusercontent.com/49749125/164887283-584478ae-445f-458f-81f5-9eb51a04163c.png)
![image](https://user-images.githubusercontent.com/49749125/164887292-8a0de8b8-3a0a-4a69-a4b1-21f21f53c01b.png)
![image](https://user-images.githubusercontent.com/49749125/164887314-a3b6a5dc-a5da-4cdc-a09b-d91e9bf5f48b.png)

> #### Not : Yukardaki ilk 5 i Relational Database ' dir. Siz EF Core ile örneğin bir NoSql bir DB ye bağlantı sağlayamazsınız. Çünkü EF Core Relational olmayan Database ler ile bir bağlantısı yok. 

> #### Örn MongoDB yi EF Core ile kullanamazsınız. Bu noktada bir MongoDB ye bağlanmak istediğinizde MongoDB nin .Net için yazılmış olan library lerini kullanıyoruz.

> #### Non Relational olarak çalışabildiği tek DB istisnai olan InMemory database ' dir. Bu zaten .Net e özgü bir database olarak düşünebiliriz.

> #### Diğerleri dataları fiziksel bir yere kaydederken InMemory tüm dataları memory de tutar. Bu da özellikle test senaryolarında hızlı sonuc almak adına kullanılabilir.

![image](https://user-images.githubusercontent.com/49749125/164888255-7fc8158e-cd32-4cc1-9e5a-f0f78f680adf.png)

![image](https://user-images.githubusercontent.com/49749125/164888322-d4f33fe7-b832-45a8-bee6-372b5a432ae8.png)

> #### Database First de bir tablo olusturmak istiyorsam gidip bunu DB de olusturuyorum daha sonra o tabloya karsılık gelecek class ımı ve DbSet imi olusturacağım.

> #### Tabi burda şöyle bir alternatif de var `Scaffolding Komutları` ile de DB de olusturdugumuz tabloların karısılıklarını kod tarafında olusturabiliriz ama bunun bir iki tane dezavantajıda da bunlardan bahsedeceğiz ilerde. 

> #### Entity dendiği zaman bu bir database de bir tabloya karsılık gelen bir class dan bahsediyor şeklinde aklınıza gelmeli.

![image](https://user-images.githubusercontent.com/49749125/164888491-6daf0e55-6327-4e08-bec0-80f3aa981ada.png)

> #### CodeFirst de ise `Migration` toolu ve komutları ile kodda ile olusturdugumuz class lara karsılık gelen Database tablolarını otomatik olarak olusturacagız.

##  `DatabaseFirst` 

![image](https://user-images.githubusercontent.com/49749125/164890392-425b0a88-15ba-46d2-af57-68da7b1fdcc5.png)
![image](https://user-images.githubusercontent.com/49749125/164890507-3c57d175-7f8b-47d4-8b50-94443feabb1e.png)

> #### Database tablomuzu olusturalım.

![image](https://user-images.githubusercontent.com/49749125/164891016-b6709eba-a086-4bc3-9b96-1daa102b0542.png)
![image](https://user-images.githubusercontent.com/49749125/164891128-d6eb086a-e28a-4ce3-a031-d634591e1d67.png)

> #### `DAL` adında bir Folder olusturalım. İlk olarak bir `DbContext` sınıfı olusturacagız. 

> #### Normalde `EFCore` library sinden gelen bir `DbContext` sınıfımız var bizim olusturacagımız class ondan inheritance alacak. 

> #### `DbContext` reserved keyword oldugundan biz kendi DbContext sınıfımıza bundan farklı bir isimlendirme yapalım. `AppDbContext` diyelim.

![image](https://user-images.githubusercontent.com/49749125/164891911-30e3e4fa-592d-4546-a426-e2966ab4b164.png)

> #### Kısaca DbSet deki props name ile veritabanındaki table name aynı ise EF Core otomatik olarak bunları eşleştirir.

> #### Eğer farklı isimler ise onun içinse yapılacak configurationları birazdan anlatacağız.

![image](https://user-images.githubusercontent.com/49749125/164892063-e12ffacd-5dfe-46f6-a4fe-52b328796d69.png)

> #### ÖNEMLİ : Artık Product class ına Entity diyebiliriz zira AppContext içerisinde DbSet<> ile Product class ını kullanarak bir prop tanımladım yani artık bu Database de bir tabloya karsılık geliyor demektir ki o zaman bu bir Entity dir diyebiliriz.

![image](https://user-images.githubusercontent.com/49749125/164893564-4bd7d2ad-7a55-425f-b9f7-94946208374f.png)

![image](https://user-images.githubusercontent.com/49749125/164893627-7c276870-43cc-435f-ba4e-9f8c303d079e.png)

![image](https://user-images.githubusercontent.com/49749125/164893678-7f25f5d1-b780-40b8-a3c1-1cb200feea0c.png)
![image](https://user-images.githubusercontent.com/49749125/164893725-ec83e984-e0b9-4f49-8cb3-64d8e17b0750.png)
![image](https://user-images.githubusercontent.com/49749125/164893765-00a72694-5f16-4427-8921-1f66c4cb54fa.png)
![image](https://user-images.githubusercontent.com/49749125/164893819-bcbb879b-df54-447e-b35b-0b1ef5a381e6.png)
![image](https://user-images.githubusercontent.com/49749125/164893956-d2110c44-29c1-42ce-b8c3-ee0f9ad51670.png)
![image](https://user-images.githubusercontent.com/49749125/164894019-d7dd4f9d-ebef-4642-b808-1b7d15fd4758.png)
![image](https://user-images.githubusercontent.com/49749125/164894064-6a74553d-36f9-4ec7-9d56-c5e1077730d9.png)
![image](https://user-images.githubusercontent.com/49749125/164894111-f0c99c7a-94af-47f4-a1f8-3b7ec7a6fe79.png)
![image](https://user-images.githubusercontent.com/49749125/164894211-148b8d7b-c332-4ca2-8f8a-5458aeec81a3.png)
![image](https://user-images.githubusercontent.com/49749125/164894384-46a481ce-0c91-4396-9df3-f7ec0b4254db.png)
![image](https://user-images.githubusercontent.com/49749125/164894509-e498f26d-7ea2-42d5-8c28-ca086c4f6fc8.png)
![image](https://user-images.githubusercontent.com/49749125/164894637-95962bbd-1d8c-4822-b645-79f2d2cc150a.png)
![image](https://user-images.githubusercontent.com/49749125/164894786-38365448-d7e1-4c55-b0fb-9a7f6ea0f77a.png)
![image](https://user-images.githubusercontent.com/49749125/164894879-26e92798-5247-4906-b145-d8670316c6aa.png)
![image](https://user-images.githubusercontent.com/49749125/164894943-dede3ecc-766f-4fb6-b0f0-3214d4f481cf.png)
![image](https://user-images.githubusercontent.com/49749125/164895068-d493b9f6-c349-4ec0-bbde-2d89ff8787ba.png)
![image](https://user-images.githubusercontent.com/49749125/164895013-2cfad7fa-21c8-4876-b322-f3bbdbff2da2.png)
![image](https://user-images.githubusercontent.com/49749125/164895338-88956ff5-fdec-4190-a6ad-641ef03641b9.png)
![image](https://user-images.githubusercontent.com/49749125/164895604-483f22f7-fcc4-45af-9e33-c967f503181f.png)
![image](https://user-images.githubusercontent.com/49749125/164896105-49ea8f7c-555c-48bf-927c-42da1e29ec9b.png)
![image](https://user-images.githubusercontent.com/49749125/164896229-f9bcac5b-9b6c-43fc-98f7-ed1390e899cf.png)
![image](https://user-images.githubusercontent.com/49749125/164896802-c3d81fdb-335d-4244-85a8-8ccf098bd433.png)
![image](https://user-images.githubusercontent.com/49749125/164896944-255845bd-c2d0-4773-a544-86a2bbd951fb.png)
![image](https://user-images.githubusercontent.com/49749125/164896983-a7daafb1-9b36-4165-973e-23053d0d003e.png)
![image](https://user-images.githubusercontent.com/49749125/164897763-b8187dd7-b03a-40a7-b553-661be12b532b.png)




`` 
