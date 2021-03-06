CREATE DATABASE [medicine]
GO

USE [medicine]
GO
/****** Object:  Table [dbo].[categories_diseases]    Script Date: 6/21/2017 10:29:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories_diseases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[categories_remedies]    Script Date: 6/21/2017 10:29:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories_remedies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[diseases]    Script Date: 6/21/2017 10:29:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diseases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[symtoms] [text] NULL,
	[image] [varchar](255) NULL,
	[category_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[diseases_remedies]    Script Date: 6/21/2017 10:29:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diseases_remedies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[diseases_id] [int] NULL,
	[remedies_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[remedies]    Script Date: 6/21/2017 10:29:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[remedies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[description] [text] NULL,
	[side_effect] [text] NULL,
	[image] [text] NULL,
	[categories_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[categories_diseases] ON 

INSERT [dbo].[categories_diseases] ([id], [name]) VALUES (2, N'common cold')
INSERT [dbo].[categories_diseases] ([id], [name]) VALUES (3, N'virus')
INSERT [dbo].[categories_diseases] ([id], [name]) VALUES (4, N'Mental')
INSERT [dbo].[categories_diseases] ([id], [name]) VALUES (5, N'heart disease')
SET IDENTITY_INSERT [dbo].[categories_diseases] OFF
SET IDENTITY_INSERT [dbo].[categories_remedies] ON 

INSERT [dbo].[categories_remedies] ([id], [name]) VALUES (3, N'herbal')
INSERT [dbo].[categories_remedies] ([id], [name]) VALUES (4, N'over the counter medicine')
INSERT [dbo].[categories_remedies] ([id], [name]) VALUES (5, N'Physical Therapy ')
SET IDENTITY_INSERT [dbo].[categories_remedies] OFF
SET IDENTITY_INSERT [dbo].[diseases] ON 

INSERT [dbo].[diseases] ([id], [name], [symtoms], [image], [category_id]) VALUES (4, N'common cold', N'running nose', N'https://countryfun.edublogs.org/files/2015/09/cold_flu-2mepljw-300x300.jpg', 3)
INSERT [dbo].[diseases] ([id], [name], [symtoms], [image], [category_id]) VALUES (5, N'Depression ', N'Persistent sad, anxious or "empty" mood.', N'http://images.agoramedia.com/everydayhealth/gcms/Coping-With-Anxiety-and-Depression-722x406.jpg', 4)
INSERT [dbo].[diseases] ([id], [name], [symtoms], [image], [category_id]) VALUES (6, N'heart attack', N'chest burn', N'https://static.independent.co.uk/s3fs-public/thumbnails/image/2016/05/17/10/heart-attack-silent.jpg', 5)
INSERT [dbo].[diseases] ([id], [name], [symtoms], [image], [category_id]) VALUES (7, N'broken leg', N'pain much pain so much pain', N'https://assets.vetary.com/media/seo_content/dog/broken-leg-med.jpg', 4)
SET IDENTITY_INSERT [dbo].[diseases] OFF
SET IDENTITY_INSERT [dbo].[remedies] ON 

INSERT [dbo].[remedies] ([id], [name], [description], [side_effect], [image], [categories_id]) VALUES (1, N'Ginger', N'Ginger is a natural herb that is used across the globe as a spice. Due to the various health benefits of ginger, this herb also is considered a virtual medicine chest. Various studies have proven that ginger is highly effective for treating a number of health problems.', N'Some people can have mild side effects including heartburn, diarrhea, and general stomach discomfort', N'http://assets.simplyrecipes.com/wp-content/uploads/2013/09/how-to-chop-ginger-vertical-a-1800.jpg', 3)
INSERT [dbo].[remedies] ([id], [name], [description], [side_effect], [image], [categories_id]) VALUES (2, N'Advil', N'Advil (ibuprofen) is a nonsteroidal anti-inflammatory drug (NSAID). Ibuprofen works by reducing hormones that cause inflammation and pain in the body.', N'upset stomach, mild heartburn, nausea, vomiting;', N'http://www.thrombocyte.com/wp-content/uploads/2015/11/is-advil-a-blood-thinner.jpg', 3)
INSERT [dbo].[remedies] ([id], [name], [description], [side_effect], [image], [categories_id]) VALUES (3, N'Mud Bath', N'The mud is a combination of local volcanic ash, imported Canadian peat and naturally heated mineral waters. Historically, the mud bath treatment has been used for centuries in Eastern and Western European spas as a way to relieve arthritis. In Romania, Lake Techirghiol is famous for treatments with mud baths.', N'Because the temperature of the mud can reach about 100 degrees Fahrenheit, water will be drained from the body and can cause dehydration. If you have sensitive skin, the warm mud may cause skin irritation. It is important to be monitored by a spa professional while taking a mud bath because staying in the bath too long can cause heat stroke, nausea and fainting.', N'data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxQTEhUUExQWFhUXGBcaGBgYFRcZFxcYFxcWFxUXFxQYHCggGBslHBYYITEiJSkrLi4uFx8zODUsNygtLisBCgoKDg0OFxAQGiwkHyQsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLCwsLP/AABEIALcBEwMBIgACEQEDEQH/xAAbAAACAwEBAQAAAAAAAAAAAAACAwABBAUGB//EAEAQAAECBAQCBwYFAgYBBQAAAAECEQADITEEEkFRYXEFIoGRobHwBhMywdHhQlJikvEUFSMzQ1NyotIHFmOCsv/EABkBAQEBAQEBAAAAAAAAAAAAAAABAgMEBf/EACERAQEAAgEEAgMAAAAAAAAAAAABAhEhAxITMUFhIjJR/9oADAMBAAIRAxEAPwBgMGIWIIR8Z9I0QQhYMGIAxBAwAghAGDBAwsQQiBgMWIAGCBgDBixAAxYMAbxbwMW8AUW8C8R4Ani3gQYt4CPEiokBbxUVFPAQmKJiPFEwEeKJiGBeAt4EmITAkwEMCYhMCTFEJgTEJgTAUTAkxZgSYCokVEgABghACLEA0GDBhIMGDAMBggYSuaEh1EAC5JYd8crE+0ctNEBS+Nh3mvhGphcvSXKT27oMWDHlj7UK/wBsfuP0h2H9qE/jlkcUl/AtGr0c/wCM+TF6UGCEY8HjUTA6FA77jmLiNIMcrNNy7MeCBhYMEIA3i4B4t4KMRbwDxHgg3i3gYkATxTxTxTwFvFExTxHgITFPFPFEwFmAJilKgXgCeBJjmY72gkSjlVMBULhPWI4FrGMf/u3DO2ZQ5oLRuYZX4Tun9d4mBJjDgulpM2kuYCdrGvAxseJZZ7Xe1kwBiEwJMQQwJMQmKMBUXAxcUAIuBghEBAxUyaEgqJYAOeQiRx/aiaRJYfiUAeVT8hGsce6yJldTbhdJ9JqnKc0SPhToOJ3MVKlkisYTNCamLwuNJVWPdrXEeWc807EzCmw58IzoxheoBjtYXo5c45ZaSo3LCg5mPSdC+z0iQtJmgTZijRIe4uzhlECrP9Ixc5HSYXJ5DD4gpIWglKh6YjUR7XojpITkPZQoobHccDGX27waUFK0gD8JYdqbcj3xxPZzEFM4bKBB8wfDxjnlrqYbX9MtPapME8LBgwY8ruJ4t4GJAGDFvACCiAgYjwLxbwFxRiRRMBIkVEgKJgSYswJiiiY4HtBMnzFJw8kMV3U9kghzwGn8x2MVPCElSrD0wjmdBdKJVOV/uLZKE1sASHVo9e6OmEvtm6t009FewMlKRnUpStTo+zbRh9q/ZCXLTnlU3GnZHoJGEne/ImqKuqCGWUSw5IKUpRUtuX7I7WOwgMvKqoIZjXxjffZd7a7MbNafDZmFynZtRRiLVj2fst0sZyClZdaLncaHnGLo/wBm5mJVMIZIQWGZ78hc24QiRhlYHFhMyykmo1STQtuFJt5x2z1nNfLzzG4c/D15MCTBAg1FooiPG7hijBNAmKBJiRG9PEiDhjpGZd090WelFjVP7fvHA/uC/wAo7QIh6TULoHcPOPT4vpx73f8A7sv9P7T/AOUc3pjGqWkBTUL0B25xm/vB/Km0ZpmOMyjClfl841h07LvTOWcs1tgm1PYfCsej9nfZE4hPvc7IF2NU7OOPzjzmKHBuX0j6P7DYEKwwLEKINXIpVgRrGutlZNxOjJby9p0H0eiUhKJYASBoL8TuYGcEKmuATkerUBbTjyiuicSwyqoYZNwaUBSjmLl2ExYqT+Fiw7o8b2x8/wD/AFEUkqStJBKiAt0qC0H8NwGCgk0N2eOH0ZNyKCjpU7x0vamcEoKSxVMmqIOuSXRJULPpHGw6qiPX05+Gnk637vWSOmn/AAHv+0aE9LpaoIO1/lHnjjiBSQe8HT+YEdL3aQW5/KOPi+nTvn9d9XTgf4DXcgfKJ/e/0H9w+kcVPSCiQ8mleJbdneJJ6RFlS8utQfl2Q8f0d/27n97/AEH9w+kGOl//AI/+w+kefPTFT1AQHY5VVOloRN6VWSQJbCoAykudA3dDwp5Hqx0pR8n/AG+0Q9Kfo/7faOfJQbECwfnrBzkkswG9njlqOjcnpMn/AE/+32iv7oW/y/8At9o5eImKDMA+YBrAudzRPbGafiFBQypc6soeBSSI1Ontm56dtXSpZ8h/d9oFPSxP+mf3faONO6TVpLPJx5wtPSUw/wCmBwKj8o14qd8dz+6n/bP7h9Io9Jn8h/cPpHKRi1G4SLal4YqcrUDnp5w8VTyRm6ax5mFIbKA5bjDfZPGIlTFqXnNUpQB8OdVHLaskB2o53jkY+YSrjFdE4kBZQugUxSf1Jq3/ANgCntEejt1hpzwz/PdfUUYtTpU6HdsmYF+ALA5uyN+MmFQtGfD4t5aSWDaCgHICkFOnZhSPNp6rk5oxEtCFZwr4h8KSpT6WqKgVj5n070scRi1KYgJ6qQbsCSSeJUox9Ln4YplqOt4+RTR/jzOCj5x16E5rj17+Meo6P6RWlASGIFnBflGg9Kr4PtlMeel4xSAG1d6bN9YpfSi3NfL6Rculu7jnj1NR6IY+Y2ndFJ6SXw7o4COkSdVdgH0izi1g2W2jsO+lInhq+WO//Vr9ARI8+ekVcO0mJDw08sOHR4IYnuO2mkGMCkUqeL/eNsmRTu4axS15bMb9W1fXKOm65aZxgQbDf1SFYbo8FZDXB05UjT71RU+UcesW77RpTiX27C/Mw3V081iMFMKiUyyE1Aubbx9K9jlBEpCVEA5Q4JatzePMqzEuCGtvprZqejAySpXxEBns7gXD08IznO+aawy7a+hdKzZIDmYEqqx5XjyU/wBosQlYQkhaCakA5e/QxyJWHFzmUa0JFOApXtEaZQYMSS7G414ARidORu9WseKwHvphmTFH9KUgJAdyd3c6iFJ6KKSGU9eFuWsdZIVZNmqSxHIhwT6tGgS2SADbf5vpHTus4c7N8uQZSiamnJsurbGpglYQhso8LHd7+hHRAG1dQBXuHZFsOF6cOyJs0wSZKTVQIULG7G/rtEaFYd6mosSKX8oZNlgF+bbjW9xygkOnM5DF6a7v31ibGDFdH5hmQQ4DsSxN2Yb0tGWSpaFBiRViQbDVyDsI7QVQvQObDe+tHYaxiweHSJ/XQ4BWwJBFsoqOcN8crJy34TEJV8Jcbj6xpZoSlLUFOUMfjHn07uZ0nOzgoSCS4fziSpQADv391I09JHqHhFy0ZUZgS7P26W9VjtjrXDln7OmYMoQFL1dkmh2sfVYxrxhCSE04kkFrHs84figSU1dwKvtQGrvyhSWdrsWJoa0NgKRqMLkMoKzk5url6proxO7AVhapBJAO+4MbUyS+Ydr6s7EVgq604cQ8Bw8R0US6nUNWbTlvGSf0YzMrrguHYGjEUPZc6x6ggXq3DRvlAzRUHTbfbytGu6p2xxsHiMSVAzCwewVfXZuyPoHQ+JQtN+sKEag8o8hNWk/i30vyMLkYkpPVUQQztRtGFvTRmzbpM7Pb23TSml86R82x3RIVOUoFgpjbVgCPB47aukZih1iojR1W0uTaEe/FtbtwL62eJjLjdrnnMppyEdFilczDal/XdBq6KS7t407o6AmqJYJYaH5tDVAbC0b3XLUYkSwDYet4MpHBuPq8FMLFmLaVHbxhKzwAPFL9xBY6wEOHTt4xIDMdlHiCG/8A0IkA5Czy4ULvuwhIvcZtWv2jnAzywtX8po9NuMIw2JahQpDUYAtZ/ibnrDQ3zeql6HmQG2/iE++e/ZlJLs+o+UNkoUUOC3VcEsX7OO8Pw+FKamr3NBzDaDhARMghxob0fbdzaG4lGUOWApcOkNrwOld4pa1D4UHgWJfnwreGSJUwuZrNcACoBOpq8ZVjxWFzAGWsBwxBDuzuw0N9DCpOEUksFsdglhVxVLk2F41qYs2dBUwBYFTXuCQkFrGGJw4SSCXLXdjagISwI5RdpoiXPWVCgCnqAqyamzVu3dG5KToqtdBoa0jFj5DgFLEaByni4yj4ufhD5M1CGST1i1z1jxreJVi1ymYhJvtTXTSuoENFRsNKX5QSp41todydm7YoqAIBL39HeCqLDj94xS0kqfKQ9WpXQX4NQQ/FTVaJJrQAbjXQ30MEJKgOsWa9Sb7li9PQghbpAIUQQQ+3AMYRh5f+IT+kMdwdo24lCSM2UOmgYudaceULw4dazyFuD/OM5XhvCctKQQND3wRDmDIpEMcdu2mPpEdQwuUhayEdVmCiSo2poPXKH4xPUu1RUXodIJUxLkKuR6FvLaOuHpyz9mKSE3IUzDbW/KEy6MzNVy+z99WgZkwkZmdj+E1FBUDWh02g0yjcCp7tKPcu3lG3MSp9ncF7O5qdDaEqxv5qhyKDYcDTleGCWWII7TbhY18Iqb0ccoJAKneob5Xdr7Q4CZGISag/E7A5rNzq2pbnBZwol7HQgHsa9Ws0GjDEgUYXIcpIILsWrvCV4UupOZTBm6zZah2ZNL6vAEmckBiB2CgGzaHhATMwqEAvQZqMatQaQXumGVqNcUAY0HDwhM8FsjBIAu5BA3D1ejVig0oUAzAhmoAxU2o2rxjLOlOBmSCQaBgDwZ6neNRnpBqe172Zzb0OUKVPLgsQ2xDt/wAbnlAKlrLlJ0BYFxTfNXzhyp4H5T+kEZu4X+8AApRNCgUqKvu+lafWNJTnYAFJcatz3ggJanBdJSeLPzFaQxwGGtedoyDDBIJf4bA2A0Faa3vAieQRQ2ezjlmBPjBWhSv0P2RIJE0tduwxIDNiMOHBN+wHV6gP46RMLLS7CrUdRJbUDMak19NALxAU3VVsSGICuw+QhiKCiFKd9g1nuR3wQ8qYMzuL7bHu7YZJU70Owcc3+fdGGQtQzDKRUEEnql9EsSfAR0EoKwCAQGqLHuHPjEqmINdCOZvftELVjK5SCS1x3s79rGKWvK4AJOylJZIDMCXcdnfCJTkMVrcVoQM2Z2SNO6tIKLDzStZaqTbNUUuwBDEUvG1OEBYkEkUD8WD0hSFrAASnLeqnUwprYd7c7RpOIUAC6S/FjvYntvEosYVlOBThS4Ne6Eq6PSksgEm/WUSC9+G2ml42lZY34kDhoYzylKsA4DC/e7a6RNjInDkAlKQgu9CSLnQUA1prGqVJoXCS9Szh2a+rwuYtT/CBxffYNWDMy9KbjUc+8RQSsQwdiNLW2o9Ryha5uYdXRzV6F2rwvbaAMl3V1k7JejV/CKecXiEApLrCeIPmH4NAAVlVDs5rRNGAYsS8DgZfxf8AL5CGypSAeqliXZgzEtVizns0MHgpZqzmqtK3MYz9N9P2eQ0CmHFNoqXLjk7Fe5fsHqsWpFaJcF/Hb0I2iV7uWpZsWAHiflGT3rtUCj10t9464+nHP2XisPYvlGope9D9toaEEVAY0d9vq3lEMxJJYh9xoTSvdFhJrmL76C+jfWNMAyrFy44tbgG424RqTVOjt49sZzIQbhzd605HTaNErDsCxN3qSfPyiKH3BDVr8uyF4mWk3bjQcrNq0a5aG18+3xiFP89lRDaMsqUAKeVn0gJ+ESSDdrEUbeNnudu3j6MWJQBJr3mLsclWDS+U5xuxNa7iukM/o5ZAcE5bZnzDtv3x0Fj1eAUl4bNMqJVCN92eAMhLg5Q4ft5gNGspgFJhtWKbhkKuFULvXwat4y4iQTQbhg23lofpHTKYBQi7TTjDoyZ/uEcMyfmHiR1sxiRe6na4qMSTQEAE2y5dKkkv6MKlzigkJUAVXBBUQKl07nSOliMQpmQnrCrZmHJ2peEYPHqNFy2V+IgsBcgj8wYXpa0VF4aShKsy3Up6BRHVpoAGvGlfSqFHKghTXALHVxeltYRiZ5T8RGW4p4F+RblGaQpBUTLTQmtAM1y9usBufOJ7G2eQUmhUR+YqA7kjaLIpmGbKKU1sQWFr6teEFOdJBWJgNaH3bbtqRTfhDg5DMWoxFARuMrVPOCgRiUBlhTrULXdh+VNvK0akYoZQSAkv+KhGgT+lyB6eDEirs7i2YjwJYmvdAyZKST1WIBFFKDu+grvpyicB+Gm5zQv4UF+cJMtSFFy2YnKQ+VJLMFP4dz2hk9IBdDZqNyIZuHOsNlTyosoNrq9rV7K7vEAmVYVPLRmsYuZKS1XFrWLtcd1IOUSoshTMNtdHBqN2iYiaRr1i4bLmSTszj5XgrGoBKi0wnNooNXZNqfWJIlZ69dALm5SeJy8/OGYrDP8AFf8AM56ouQHcC/hByDmZlBSXowpTRRr8oIZJSok1JTeotyIoRfjWDkatr3QVkO9bG7nlEwkoG5YNSmugjGTpg0pTSE5TWNYT1RSsFLwSjsOZjGm96YphPuVFVgS3B3evZGD3ZovMkEAXZiOyoPhHX6fwwRICaqzX2oIwSkaBLhmJoDR2ve5746YuVKlylKNCKEO4NXIPVNvDtjoTwNNqsW15xmlYUCrbOXIB45dC8axh6M9uNhpfgItSF7OO42i5c6vOledDeIUkE176DQ03tElyGr9QXFfnAPWWP28IXmPCvGnpolXY/ZuUMSO6IIPRi4AD0W9PBwAmFqT6eGiJlgM6ktvC81PQ841ZQBQUGwpCZg4QCDAkAw0iAKYoQU+qRI0JA2iRRyETQE/G+ZuqcoVUfpat4qbLzH4SUkAPmsBXd9opWAQ6nSns2OprTz4wOHwAQkf4hoxdSh2Mb2p/Ma4ZAZKwcyVIyAbk5SOL18IacOmakhVRT8zaF2NxyLQ5KksXU5a9gS7W5mIlISlROdIZ2KiTStGq/wBuUTakypQdiUVDZWSHIo7ORSka5aK5auLkOzHmGJPAdsBIkAB9PyhKQom1TqRWNucJYDK+oA8RoKmFGfM4GWrGlWB3remYw33ig/VtYAX2brfKHKUHLX5cvrCBKIObXKX/ADEhsoB7DfeMqzieSQGYPSgdKtnFAas5vaNLlhmZRFjlbvD10tGSeQpNFZexzTQ8ac6QUrFuyKhRDsxqkUNSxpudWio2Yea5cAPwbuPEV7Ycam1tywBHNntpHM/qcqsqkqSSWBe+Z3NLNSp3jdMmlJSnKVDUuzUo6drRFNxLkDKxGoOuzMeEZAiYTmz01TlDNqXLNVjrrzg1BlUKQGdgllVu5dmbcQSGCeqUtVyLVs5epFKwGOdNKBQJAarbk6HUN8o6WHSWDDYX8Y5E6Xlyh6qI5MLU7zHewMugcxnP4bw9HKUdjGrAyyQS5erDU8Kxl/EXBZ++NaMKJigxUK7h23f7RmTlbeHnukcdP98lE+WyFUHw05Ma840sbgilweVNWdt/5P2hCVzgUjMkJ+MEGosAO0xnTILsWY3B1JNX4c9zHRzMkT0FeUTCpTZjYjKbsBpb7xrRIKauVJvqb6XtGReFG6RuRStKAAWdh2RpVNySxlL2Aeh2v4wqFrngjK2XetgTQ11PPeH4WWAnKNzdy/eYTh8UQWuNVBgOJfVz5xtKxve0RS8lXD1p3aRYD6N9okyZUeL/AFgi1IASIBamOpFa7c4YSPW8Bk3sXgKUe6KJ7RFOxYn0PQiZ2tWAilPfaFt6esCia5s23bEUYoopiimLI3MW72rALESDpFQHKlprlB+EDUEvox7C/OM8xJzs3Vcuo1voCLJhYkEFkhIDksCoEkaULJ1D1+UMBILZHJqpiG/eQHpGmWkTPdoOUAsCWcdpcxmlqnLYlkpagD5i4cuXYDiwMWqUAzkAjVuqBoKlv45QxU4gZUpJN3DBIrRy44cR2wUScSE3dydiXYVb0Hipk0oLuPeKoAQK3ZNL3gMPKISpwrMTezZstQok6V7IdKw6pdVLCr9ZQZVRQZh5wDVoAGYs4LswppSkOE0sHATSxJ2d7aWhWagKetSg02D60bzi1LS4LjMQKBqCnFiPrxiA5c4KDu6dCKu51IoA0T+kS4U4vq5ajUrT790GGLkgsGqLVsC77aQuVNUEhOUKJr1SkUOpc9tBEU4YpIBYuQKi6vXAwMieVVCWGuZw7tanO8KlyuqActHNNnoBZvtBKmKAYOUk37Dv9IqNstCQ7VIFTo1TeOfiShGrFWpc9p1AfsgwZgDdUBQZwHarABL8ztSMWHlJSplKC1j4cz5g40dRZnenGEgg94pUtawyCSlH6soNQBYfaO7g0aWfnGTEpGaSOEw73KBXY08Y6cqSQlZuSKcQGduLPGMua3OIT0hjT7xEpCgOq6iO0AV1p5RjTjViaUg1AoRQlzuKmMBV/jKP6e0VIYjQxE/512p3+r9kJErXjZi5ZSUylTAQzJbq8xfhrFysWqYlylgSQkkbC+RTKjq9F4gtkUA70cDwZ9dRCOl0zSsKQlJIABBVlSzOCeq7uR3RrfwjnhKlhiwUm5YsXcPz1jTJQCHUaN1g4N7vWgraOfiZExgsZlKsUhsrE16qvPuh68LNzJZk/nNzRmTTzrYXio1rQoAhKAEhmA8RSH9FyVgHPQGwYAjuMYMNjAmpCw5y7ihajfaOjJxgJax7HGzh+MRWpYhKVsSKb6WhkZsXJeouzU21iCT5qUM5bQOb/WF4jEAp+Jm1cWjkjELUAzpIoyk1oD+HRiIJ8gzqcO7i5JpQAP4bxdI1y1pKsuZ+q7OCCHqWAtaNFnc09PwvTujDIljMFGh0q5bUWoaeGujP6gqTRVXKSLG9iFbteAauY7F6OGpezB4WmcLGlTxB8LM8Ysqklio3JYgUBNBSgMBMROcgBIFbrU5vsPI1pGtDoqnfmF3ZtmArC0zcx6tCG18bRzkrVQ5jqFVcpua6i3OsbZaBQihNS9CXDEnsbuhoKmSEKJJUsE3yzVJD8EhVIkMEgjf+axIDnzsMFAgEgUGZKiCGNgRa8KlMjMCoZUh2JJVZ7E1Ju54Q2biShAUSAWNCXtaulKxnw+JmzglKpZSlRqctG0ckMX4NFRvSpK0FQNCBVTAEaDcaGmsc6RilLWZaCEoQzKFXbQg6OPCDndGTEEGWpISHLlwpAGwBbw2aNkhISAlRDnnU3qSa25wFz5hCgFFWZ2A6qXrs5DW2uHilLWApagzWS6SojbNqdaWrGyViVrmKC9GYp+HKat48KQzI1lEgO9qcCRVoyrl4jH+7LFK0ywOtMKVPqWLl6UqL2jn4XHZ1LmJQxFUKUEglIoQlAqokhw+8epVLSweoaxtxJBr/ADHNxMsJHVDMKZSAq4ynQAeqxZYmjcJMCwcyitwGBoQwrQWNqHWC/qfhSWQlqqKgFMPws1O/xjAhJdJ+FRsM+c60NwbmosO6HM7pJUv8xOVmuPhtR6PDSuiqtjlSbgpvvUlu2sZpyMyQkE6gVPxM1ddK3gsHIKQEglTFjQ0oSMoGoLX3jdNl0DJ6zZXtekQKlyFCWkqNUgAhNatdzpV4rD4PMsA5SrQuzAbA0FTeHrTloo2qdACdvrHPkTphUSkICSTkVmd23BpZ4g6GMw/u5iZbUA4lySo9j08YbLmZUsK0vC1S1TCpS1EqZIpQfCDYcVGET5YSCHJ5k08nMYu3Sac6Yt5q/wDiIvDKAnBxRrQnCJ68zsiTS03sjfwzrnT08uYDeo529PF45wosxSQki2wBoOR745Eqe3rSN+OmqKwWGUhNXrbUWbW8Yl2uU0yYhSvdn3ZGc7ks7uzaRmw/vWeZlVfqpJoNCC1zSNqcOAVFmJZyG2IcvctElIUDRRPEtan3rWNslKmJT1V0SWFfhfbYX5GEqSg1TRBP4fhOVgEltH8zxjWqWCCJjEE1cUPMHRwYzTcIArNLUpJewJKL1BDUB4QDsPNKqEhJemUvu7OALDzhypiwUlrsKfMCn8RSwAKJqWApR9DyiglkkKcjkzAcogv3AUXFC9XcOKig9PCsWkJIBqNqkqIF+xtYXInnMUkK0KVG2XTV6FvVY0LVVJLg92mu8UZVqFyMhJIBap4N304Q5CU5mNOrTRwCK3ekHNm2cA1501YXgFkAl/qW1oK3gBXKChVjxLMWjKuZlATZ3bbiHtSNi5QUwOagdwCAabg7X5xkxEjOllEZQeqAxPj8o1ELkT8ymy5S1C4ruLvSzwc1JIBBSTUguWFOAfThaM2HmIl0loyg3IBABLO4NjGgYRBZ6kVBIZjqfHxioIzTooNyJtS7RIWtMslwEftHm8VEGLono5DlRTVywc5XDgHISQ/GOvNzJSyQP097nk8VEhbyRjKiRWpYkVOXYA6790CJ2VJG3xNQDjfjziRIosKCUmYAS9Lj13xcme5dL2dnonN8PVIYnt+kSJDQeueVEAu5BszuLto9r08orDy7Jul65qklXEM3jpEiRlS8X0albl8oFHDlZN2zE9VMYMTi0oWiUmXnNQWVkDOA6vzENEiRceUrq4eeTMCUEm+cflPEm9bNHZkoc3p8wIkSM1WHF5VKJIzO5ctpRgbjnDOi0IKlKIqEnK75Us2gLk0vFxIX0KlTOusjVRLCgu1PGEYo7W9GLiRxy9u+HpzsEHVM5jyELxv+b2RIkdb6cp+zSkN3+hHUJC5Q3Hjt8xEiRiXmumc4h6lAZatsGvrC1SilWYbMRx4RUSNuS85IJoQDeoq1QR9IypQWKwHo12Batm1PCJEgDlS0llgVU3cQ5hSM/WAYpemjjUHY8YuJFDDOCg+w6vZSAXiEuitS7AvVqKdqbRIkNADMC0kkEBzrsbhrfaIp6EiqdTqDytEiQFImqJCgkg1uQw0DgHxglz6KzpqGoLVZzyuW4xcSCFSsqwCCQ1WFv0+NRa8FJWFEjUCvGp+hiRIoQZssOARc6K34CLiRI1of/9k=', 5)
SET IDENTITY_INSERT [dbo].[remedies] OFF
