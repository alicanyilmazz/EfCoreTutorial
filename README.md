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


`` 
