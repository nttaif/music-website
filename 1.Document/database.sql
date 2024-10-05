create database QL_WebNgheNhac
use QL_WebNgheNhac

CREATE TABLE AdminUser
(
  ID int identity(1,1) NOT NULL,
  NameUser VARCHAR(max) NOT NULL,
  EmailUser VARCHAR(max) NOT NULL,
  RoleUser VARCHAR(max) NOT NULL,
  PasswordUser VARCHAR(max) NOT NULL,
  PRIMARY KEY (ID)
);

CREATE TABLE Singer
(
  ID_Singer int identity(1,1) NOT NULL,
  Name_singer NVARCHAR(max) NOT NULL,
  Story NVARCHAR(max) NOT NULL,
  View_moth INT NOT NULL,
  ImgSinger NVARCHAR(max) NOT NULL,
  PRIMARY KEY (ID_Singer),
);
CREATE TABLE Song
(
  ID_Song int identity(1,1) NOT NULL,
  Name_Song NVARCHAR(max) NOT NULL,
  ID_Catergory int NOT NULL,
  Release_Date DATE NOT NULL,
  Audio_Song NVarchar(max) Not null,
  ImageSong NVARCHAR(max) NOT NULL,
  View_Song INT,
  ID_Singer int NOT NULL,
  PRIMARY KEY (ID_Song),
  FOREIGN KEY (ID_Singer) REFERENCES Singer(ID_Singer),
  FOREIGN KEY (ID_Catergory) REFERENCES Catergory(ID_Catergory)
);
Create table Catergory(
	ID_Catergory int identity(1,1) Not null primary key,
	Name_Catergory nVarChar (max) not null,
);
Create table Library_Music
(
	ID_Library int identity(1,1) not null primary key,
	ID_AdminUser int not null,
	ID_Song int not null,
	FOREIGN KEY (ID_AdminUser) REFERENCES AdminUser(ID),
	FOREIGN KEY (ID_Song) REFERENCES Song(ID_Song),
);

--add catergory--
insert into Catergory(Name_Catergory)
values ('Pop');
insert into Catergory(Name_Catergory)
values ('Rap');
insert into Catergory(Name_Catergory)
values ('Melody');
insert into Catergory(Name_Catergory)
values ('R&B');

insert into AdminUser(NameUser,EmailUser,RoleUser,PasswordUser)
values ('admin','admin@123','admin','123');
select * from AdminUser
--add singer--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('HURRYKNG','THIS IS HURRYKNG..YEAH',0,'~/Content/images/chua-phai-la-yeu.jpg')


insert into AdminUser(NameUser,EmailUser,RoleUser,PasswordUser)
values ('admin','admin@123','admin','123');
select * from AdminUser
--add singer--
--1--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values (N'Tăng Duy Tân, Rum7', N'Nguyễn Tăng Duy Tân, thường được biết đến với nghệ danh là Tăng Duy Tân, là một ca sĩ kiêm nhạc sĩ người Việt Nam, sinh ra và lớn lên tại huyện Hải Lăng, tỉnh Quảng Trị',0,'~/Content/images/tangduytan.jpg')
--2--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values (N'Sơn Tùng M-TP', N'Nguyễn Thanh Tùng, thường được biết đến với nghệ danh Sơn Tùng M-TP, là một nam ca sĩ kiêm sáng tác nhạc, rapper và diễn viên người Việt Nam. Sinh ra ở thành phố Thái Bình',0,'~/Content/images/sontung.jpg')
--3--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('Nal', N'Hồ Phi Nal sinh năm 1997, quê Đồng Tháp. Anh cho biết bố mẹ anh là người có đam mê ca hát nhất là dòng nhạc bolero, ca cổ',0,'~/Content/images/nal.jpg')
--4--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('B-Ray',N'B Ray sinh ra tại Thành phố Hồ Chí Minh, từ nhỏ cùng gia đình đến sinh sống tại Mỹ. Anh theo học ngành dược và làm y tá ở Mỹ. Khi lớn lên, anh trở về Việt Nam để theo con đường âm nhạc.',0,'~/Content/images/bray.jpg')
--6--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('QNT',N'Trần Mạnh Quang, sinh năm 1994 tại Hà Nam, QNT (viết tắt từ tên Quang Ngọc Trinh). Anh là cái tên quen thuộc trong cộng đồng underground Việt và giới streamer hiện nay. Ngoài được biết đến với vai trò streamer, QNT còn nổi tiếng với những sản phẩm âm nhạc tự sáng tác',0,'~/Content/images/qnt.jpg')
--7--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('BigDaddy',N'BigDaddy tên thật là Trần Tất Vũ, là một rapper rất thành công người Việt. BigDaddy sinh năm 1991 ngày 05 tháng 08 thuộc cung Sư Tử, năm nay Big Daddy 32 tuổi. BigDaddy quê ở Hà Nội',0,'~/Content/images/bigdaddy.jpg')
--8--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('HieuThuHai',N'Trần Minh Hiếu, thường được biết đến với nghệ danh Hieuthuhai, là một nam rapper, ca sĩ kiêm sáng tác nhạc và diễn viên người Việt Nam. Anh hiện đang là thành viên của nhóm nhạc Gerdnang',0,'~/Content/images/hieuthuhai.jpg')
--9--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('Freaky',N'Freaky là một trong những rapper người Việt Nam. Anh được giới trẻ biết tới qua những bản nhạc rap vô cùng ấn tượng của mình. Mặc dù không sinh ra trong gia đình có truyền thống âm nhạc nhưng Freaky đã có đam mê hip hop ngay từ khi còn nhỏ',0,'~/Content/images/freaky.jpg')
--10--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('Chilles, GreyD',N'Chillies là một Band Nhạc indie Việt Nam gồm 5 thành viên: Trần Duy Khang, Nhím Biển, Nguyễn Văn Phước, Sĩ Phú và Tô Đông Phong. Nhóm được thành lập vào tháng 10 năm 2018 và được quản lý bởi hãng đĩa Warner Music Vietnam',0,'~/Content/images/chilles.jpg')
--11--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('One Direction',N'One Direction được quan niệm là nhóm nhạc mới nổi tỏa sáng trong các nhóm nhạc nam, và là gương mặt tiêu biểu trong "Làn sóng Anh Quốc" tại Mỹ. Nhóm đã tiêu thụ được 8 triệu bản album và 14 triệu bản đĩa đơn trên toàn thế giới',0,'~/Content/images/onedirection.jpg')
--12--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('Maroon 5',N'Maroon 5 là một ban nhạc pop rock người Mỹ đến từ Los Angeles, California.[1][2][3] Nổi tiếng từ năm 2004 sau single "This Love", sự nghiệp của Maroon 5 liên tục có những bước tiến vững chắc.',0,'~/Content/images/maroon5.jpg')
--13--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('Alan Walker',N'Alan Olav Walker, thường được biết đến với nghệ danh Alan Walker là một nam DJ và nhà sản xuất thu âm người Anh gốc Na Uy Vào năm 2015, Alan bắt đầu trở nên nổi tiếng trên phạm vi quốc tế sau khi phát hành đĩa đơn "Faded"',0,'~/Content/images/alanwalker.jpg')
--14--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('Wiz Khalifa',N'Cameron Jibril Thomaz, được biết đến qua nghệ danh là Wiz Khalifa, là một rapper người Mỹ, ca sĩ kiêm nhạc sĩ và diễn viên, anh nổi tiếng từ khi ra bài hát "See You Again"',0,'~/Content/images/wizkhalifa.jpg')
--15--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('Shayne Ward',N'Shayne Thomas Ward là một ca sĩ nhạc pop người Anh, được biết đến nhiều hơn qua cái tên Shayne Ward. Shayne bắt đầu nổi tiếng nhờ chiến thắng của mình tại cuộc thi The X Factor đợt hai năm 2005',0,'~/Content/images/shayneward.jpg')
--16--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('JungKook',N'Jeon Jung-kook, thường được biết đến với nghệ danh Jungkook, là một nam thần tượng K-pop kiêm nhạc sĩ người Hàn Quốc. Anh là thành viên trẻ tuổi nhất và là giọng ca chính của nhóm nhạc nam Hàn Quốc BTS',0,'~/Content/images/jungkook.jpg')
--17--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('BigBang',N'Big Bang, là một nhóm nhạc nam Hàn Quốc được thành lập bởi YG Entertainment, chính thức ra mắt năm 2006. Nhóm gồm 5 thành viên G-Dragon, T.O.P, Taeyang, Daesung và Seungri',0,'~/Content/images/bigbang.jpg')
--20--
Insert into Singer(Name_singer,Story,View_moth,ImgSinger)
values ('Jisoo',N'Kim Ji-soo, thường được biết đến với nghệ danh Jisoo, là một nữ ca sĩ, diễn viên người Hàn Quốc. Cô là thành viên của nhóm nhạc nữ Hàn Quốc Blackpink do công ty YG Entertainment thành lập vào tháng 8 năm 2016',0,'~/Content/images/jisoo.jpg')
--view singer--
select * from Singer
--add Song--
select * from Catergory
--1--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Cắt đôi nỗi sầu',1,'2023-10-02',N'/Content/music/cat-doi-noi-sau.mp3','/Content/images/CatDoiNoiSau.jpg',1)
--2--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Muộn rồi mà sao còn',1,'2021-04-09',N'/Content/music/muon-roi-ma-sao-con.mp3','/Content/images/Muonroimasaocon.jpg',2)
--3--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Rồi tới luôn',1,'2021-07-25',N'/Content/music/roi-toi-luon.mp3','/Content/images/Roitoiluon.jpg',3)
--4--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Cao ốc 20',2,'2019-06-23',N'/Content/music/cao-oc-20.mp3','/Content/images/Caooc20.jpg',4)
--5--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Xin đừng nhấc máy',2,'2021-04-01',N'/Content/music/xin-dung-nhat-may.mp3','/Content/images/xindungnhacmay.jpg',5)
--6--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Say em',2,'2020-10-28',N'/Content/music/say-em.mp3','/Content/images/Sayem.jpg',6)
--7--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Ngõ chạm',1,'2023-08-03',N'/Content/music/ngo-cham.mp3','/Content/images/Ngocham.jpg',7)
--8--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Không thể say',2,'2023-04-19',N'/Content/music/khong-the-say.mp3','/Content/images/Khongthesay.jpg',8)
--9--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Muốn quên được em',1,'2023-07-18',N'/Content/music/muon-quen-duoc-em.mp3','/Content/images/Muonquenduocem.jpg',9)
--10--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Đưa em về nhàa',1,'2023-04-24',N'/Content/music/dua-em-ve-nha.mp3','/Content/images/Duaemvenha.jpg',10)
--11--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'What make you beautiful',1,'2011-08-19',N'C/ontent/music/what-make-you-beautiful.mp3','/Content/images/whatmakeyoubeautiful.jpg',11)
--12--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Map',2,'2014-06-24',N'/Content/music/map.mp3','/Content/images/Map.jpg',12)
--13--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Faded',1,'2015-12-04',N'/Content/music/faded.mp3','/Content/images/faded.jpg',13)
--14--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'See you again',1,'2015-04-07',N'/Content/music/see-you-again.mp3','/Content/images/seeyouagain.jpg',14)
--15--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Until you',3,'2015-12-16',N'/Content/music/until-you.mp3','/Content/images/untilyou.jpg',15)
--16--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Seven',1,'2023-07-14',N'/Content/music/seven.mp3','/Content/images/seven.jpg',16)
--17--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Blue',1,'2012-02-12',N'/Content/music/Blue.mp3','/Content/images/blue.jpg',16)
--18--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Still life',1,'2022-04-04',N'/Content/music/still-life.mp3','/Content/images/stilllife.jpg',16)
select * from Singer
--19--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Haru haru',1,'2008-10-03',N'/Content/music/haru-haru.mp3','/Content/images/haruharu.jpg',16)
--20--





--1--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Cắt đôi nỗi sầu',1,'2023-10-02',N'/Content/music/cat-doi-noi-sau.mp3','/Content/images/CatDoiNoiSau.jpg',0,1)
--2--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Muộn rồi mà sao còn',1,'2021-04-09',N'/Content/music/muon-roi-ma-sao-con.mp3','/Content/images/Muonroimasaocon.jpg',0,2)
--3--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Rồi tới luôn',1,'2021-07-25',N'/Content/music/roi-toi-luon.mp3','/Content/images/Roitoiluon.jpg',0,3)
--4--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Cao ốc 20',2,'2019-06-23',N'/Content/music/cao-oc-20.mp3','/Content/images/Caooc20.jpg',0,4)
--5--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Xin đừng nhấc máy',2,'2021-04-01',N'/Content/music/xin-dung-nhat-may.mp3','/Content/images/xindungnhacmay.jpg',0,4)
--6--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Say em',2,'2020-10-28',N'/Content/music/say-em.mp3','/Content/images/Sayem.jpg',0,5)
--7--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Ngõ chạm',1,'2023-08-03',N'/Content/music/ngo-cham.mp3','/Content/images/Ngocham.jpg',0,6)
--8--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Không thể say',2,'2023-04-19',N'/Content/music/khong-the-say.mp3','/Content/images/Khongthesay.jpg',0,7)
--9--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Muốn quên được em',1,'2023-07-18',N'/Content/music/muon-quen-duoc-em.mp3','/Content/images/Muonquenduocem.jpg',0,8)
--10--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Đưa em về nhàa',1,'2023-04-24',N'/Content/music/dua-em-ve-nha.mp3','/Content/images/Duaemvenha.jpg',0,9)
--11--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'What make you beautiful',1,'2011-08-19',N'Content/music/what-make-you-beautiful.mp3','/Content/images/whatmakeyoubeautiful.jpg',0,10)
--12--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Map',2,'2014-06-24',N'/Content/music/map.mp3','/Content/images/Map.jpg',0,11)
--13--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Faded',1,'2015-12-04',N'/Content/music/faded.mp3','/Content/images/faded.jpg',0,12)
--14--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'See you again',1,'2015-04-07',N'/Content/music/see-you-again.mp3','/Content/images/seeyouagain.jpg',0,13)
--15--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Until you',3,'2015-12-16',N'/Content/music/until-you.mp3','/Content/images/untilyou.jpg',0,14)
--16--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Seven',1,'2023-07-14',N'/Content/music/seven.mp3','/Content/images/seven.jpg',0,15)
--17--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Blue',1,'2012-02-12',N'/Content/music/Blue.mp3','/Content/images/blue.jpg',0,16)
--18--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Still life',1,'2022-04-04',N'/Content/music/still-life.mp3','/Content/images/stilllife.jpg',0,16)
--19--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Haru haru',1,'2008-10-03',N'/Content/music/haru-haru.mp3','/Content/images/haruharu.jpg',0,16)
--20--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Flower',1,'2023-03-31','/Content/music/flower.mp3','/Content/images/flowerjisoo.jpg',0,17)
--21--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Lạc trôi',1,'2017-01-01','/Content/music/LacTroi.mp3','/Content/images/lactroi.jpg',0,2)
--22--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Hãy trao cho anh',1,'2019-07-01','/Content/music/Haytraochoanh.mp3','/Content/images/haytraochoanh.jpg',0,2)
--23--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Chúng ta của hiện tại',1,'2020-12-20','/Content/music/Chungtacuahientai.mp3','/Content/images/chungtacuahientai.jpg',0,2)
--24--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Em của ngày hôm qua',1,'2014-03-10','/Content/music/Emcuangayhomqua.mp3','/Content/images/emcuangayhomqua.jpg',0,2)
--25--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Thức dậy đi',1,'2023-06-23','/Content/music/Thucdaydi.mp3','/Content/images/thucdaydi.jpg',0,3)
--26--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Rồi nâng cái ly',1,'2021-12-21','/Content/music/Roinangcaily.mp3','/Content/images/roinangcaily.jpg',0,3)
--27--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Lửng lơ',1,'2019-04-01','/Content/music/Lunglo.mp3','/Content/images/lunglo.jpg',0,4)
--28--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Do for love',2,'2020-02-14','/Content/music/Doforlove.mp3','/Content/images/doforlove.jpg',0,4)
--29--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Xin',1,'2018-03-25','/Content/music/Xin.mp3','/Content/images/xin.jpg',0,4)
--30--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Querry',2,'2022-06-01','/Content/music/Querry.mp3','/Content/images/querry.jpg',0,5)
--31--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Ngủ một mình',2,'2022-12-15','/Content/music/Ngumotminh.mp3','/Content/images/ngumotminh.jpg',0,7)
--32--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Hẹn gặp em dưới ánh trăng',2,'2021-03-26','/Content/music/Henemduoianhtrang.mp3','/Content/images/hengapemduoianhtrang.jpg',0,7)
--33--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Bật nhạc lên',2,'2020-06-01','/Content/music/Batnhaclen.mp3','/Content/images/batnhaclen.jpg',0,7)
--34--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Vùng ký ức',1,'2020-03-17','/Content/music/Vungkyuc.mp3','/Content/images/vungkyuc.jpg',0,9)
--35--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Một cái tên',1,'2021-05-23','/Content/music/Motcaiten.mp3','/Content/images/vungkyuc.jpg',0,9)
--36--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Qua khung cửa sổ',1,'2020-11-11','/Content/music/Quakhungcuaso.mp3','/Content/images/quakhungcuaso.jpg',0,9)
--37--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Story of my life',1,'2013-11-03','/Content/music/Storyofmylife.mp3','/Content/images/storyofmylife.jpg',0,10)
--38--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'One thing',1,'2012-01-13','/Content/music/Onething.mp3','/Content/images/onething.jpg',0,10)
--39--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Sugar',1,'2015-01-14','/Content/music/Sugar.mp3','/Content/images/sugar.jpg',0,11)
--40--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Girls like you',1,'2018-05-31','/Content/music/Girlslikeyou.mp3','/Content/images/girlslikeyou.jpg',0,11)
--41--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Wake me up',1,'2013-07-29','/Content/music/Wake-me-up.mp3','/Content/images/wakemeup.jpg',0,20)
--42--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Addicted to you',1,'2014-02-14','/Content/music/Addicted-to-you.mp3','/Content/images/addictedtoyou.jpg',0,20)
--43--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Left and right',1,'2022-06-24','/Content/music/Left-and-right.mp3','/Content/images/leftandright.jpg',0,23)
--44--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Cheating on you',1,'2019-10-02','/Content/music/Cheating-on-you.mp3','/Content/images/cheatingonyou.jpg',0,23)
--45--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Spectre',1,'2017-09-15','/Content/music/Spectre.mp3','/Content/images/spectre.jpg',0,12)
--46--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'On my way',1,'2019-03-21','/Content/music/On-my-way.mp3','/Content/images/onmyway.jpg',0,12)
--47--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Em iu',2,'2022-01-30','/Content/music/Em-iu.mp3','/Content/images/emiu.jpg',0,27)
--48--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Nhạc anh',2,'2020-12-18','/Content/music/Nhac-anh.mp3','/Content/images/nhacanh.jpg',0,27)
--49--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Đủ trải sẽ thấm',2,'2022-06-24','/Content/music/Du-trai-se-tham.mp3','/Content/images/dutraisetham.jpg',0,30)
--50--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Changes',3,'2018-03-02','/Content/music/Changes.mp3','/Content/images/changes.jpg',0,29)
--51--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Giàu vì bạn, sang vì vợ',3,'2020-10-25','/Content/music/giau-vi-ban-sang-vi-vo.mp3','/Content/images/giauvibansangvivo.jpg',0,33)
--52--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Dân chơi xóm',3,'2020-11-14','/Content/music/dan-choi-xom.mp3','/Content/images/danchoixom.jpg',0,33)
--53--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Dám hay không dám',3,'2020-08-03','/Content/music/dam-hay-khong-dam.mp3','/Content/images/damhaykhongdam.jpg',0,34)
--54--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Chú bé loắt choắt',3,'2020-08-30','/Content/music/chu-be-loat-choat.mp3','/Content/images/chubeloatchoat.jpg',0,35)
--55--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Anh vẫn okay',3,'2020-08-30','/Content/music/anh-van-okay.mp3','/Content/images/anhvanok.jpg',0,33)
--56--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'NGTANOISE',3,'2022-09-12','/Content/music/ngtanoise.mp3','/Content/images/ngtanoise.jpg',0,36)
--57--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Va vào giai điệu này',3,'2020-11-09','/Content/music/va-vao-giai-dieu-nay.mp3','/Content/images/vavaogiaidieunay.jpg',0,33)
--58--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Falling on you',3,'2021-10-19','/Content/music/falling-on-you.mp3','/Content/images/fallingonyou.jpg',0,36)
--59 perfect - ed sheeran--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Perfect',3,'2017-08-21','/Content/music/Perfect(1).mp3','/Content/images/Perfect.jpg',0,18)
--60--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Set fire to the rain',3,'2011-11-16','/Content/music/Set-fire-to-the-rain.mp3','/Content/images/Set Fire to the Rain.jpg',0,19)
--61--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('The nights',3,'2014-12-16','/Content/music/the-nights.mp3','/Content/images/thenight.jpg',0,20)
--62--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Waiting for love',3,'2015-06-26','/Content/music/waiting-for-love.mp3','/Content/images/waitingforlove.jpg',0,20)
--63--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Baby',1,'2010-02-19','/Content/music/baby.mp3','/Content/images/Baby.jpg',0,21)
--64--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Cupid',1,'2023-02-23','/Content/music/cupid.mp3','/Content/images/Cupid - Twin Ver.jpg',0,22)
--65--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Dangerously',1,'2016-11-03','/Content/music/dangerously.mp3','/Content/images/Dangerously.jpg',0,23)
--66--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('deja vu',1,'2021-04-01','/Content/music/deja-vu.mp3','/Content/images/deja vu.jpg',0,24)
--67--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Night change',1,'2014-11-21','/Content/music/night-changes.mp3','/Content/images/Night Changes.jpg',0,10)
--68 perfect - onedirection --
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Perfect',1,'2015-10-21','/Content/music/perfect.mp3','/Content/images/Perfect1.jpg',0,10)
--69--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('You set my world on fire',1,'2020-05-19','/Content/music/you-set-my-world-on-fire.mp3','/Content/images/You Set My World On Firejpg.jpg',0,25)
--70--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('a m a r i',2,'2021-05-18','/Content/music/a-ma-ri.mp3','/Content/images/a m a r ijpg.jpg',0,26)
--71--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Chơi như tụi Mỹ',2,'2022-12-29','/Content/music/choi-nhu-tui-my.mp3','/Content/images/Chơi Như Tụi Mỹ.jpg',0,27)
--72--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Chưa phải là yêu',2,'2023-09-22','/Content/music/chua-phai-la-yeu.mp3','/Content/images/Chưa phải là yêu.jpg',0,28)
--73--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Look At Me!',2,'2017-05-25','/Content/music/look-at-me.mp3','/Content/images/Look At Me!.jpg',0,29)
--74--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values (N'Nụ hôn Bisou',2,'2022-10-27','/Content/music/nu-hon-bisou.mp3','/Content/images/Nụ hôn Bisou.jpg',0,30)
--75--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Stan',2,'2009-12-25','/Content/music/stan.mp3','/Content/images/stan.jpg',0,31)
--76--
Insert into Song(Name_Song,ID_Catergory,Release_Date,Audio_Song,ImageSong,View_Song,Id_Singer)
values ('Better Now',3,'2018-10-06','/Content/music/Better-now.mp3','/Content/images/Better Nowjpg.jpg',0,32)


