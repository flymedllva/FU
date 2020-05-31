# 1

hist(quakes$mag)
hist(quakes$depth)

plot(quakes$mag, 
     quakes$depth, 
     col="red", 
     xlab="Магнитуда", 
     ylab = "Глубина", 
     main = "Магнитуда/глубина землетрясений")

# 2
tab <- read.csv2("data.csv", encoding = "UTF-8")
df <- data.frame(tab)

palet <- colorRampPalette(c("lightgreen", "darkgreen"))
colors <- palet(14)
barplot(height = tab$znachenie_pokazatelya[1:14],horiz = T,col=colors)

# 3

library(dplyr)
stormamy <- filter(storms, name == "Amy")
plot(stormamy$lat, 
     stormamy$long,
     type = "l",
     col = "red")
text(stormamy$lat, 
     stormamy$long,
     labels = stormamy$wind,
     cex = 0.55,
     pos = 4)
points(stormamy$lat,stormamy$long, pch=20, col="blue",cex=stormamy$wind/30)


# 4
tab <- read.csv("okruga.csv", encoding = "UTF-8")
(df <- data.frame(tab))
years <- c(2005, 2010, 2011, 2012, 2013)

plot(range(years), 
     range(df$X2005,df$X2010,df$X2011,df$X2012,df$X2013), 
     type="n", 
     main="Население федеральных округов России", 
     xlab="Год", 
     ylab="Тыс.чел.",
     cex.axis=0.9, 
     cex.lab=0.7, 
     cex.main=0.9, 
     col.lab = "grey50", 
     fg = "grey40",
     xlim=c(2005,2025))

points(years, c(df$X2005[1],df$X2010[1],df$X2011[1],df$X2012[1],df$X2013[1]), pch=20, col="red3")
lines(years, c(df$X2005[1],df$X2010[1],df$X2011[1],df$X2012[1],df$X2013[1]), pch=20, col="red3")

points(years, c(df$X2005[2],df$X2010[2],df$X2011[2],df$X2012[2],df$X2013[2]), pch=20, col="blue")
lines(years, c(df$X2005[2],df$X2010[2],df$X2011[2],df$X2012[2],df$X2013[2]), pch=20, col="blue")

points(years, c(df$X2005[3],df$X2010[3],df$X2011[3],df$X2012[3],df$X2013[3]), pch=20, col="green")
lines(years, c(df$X2005[3],df$X2010[3],df$X2011[3],df$X2012[3],df$X2013[3]), pch=20, col="green")

points(years, c(df$X2005[4],df$X2010[4],df$X2011[4],df$X2012[4],df$X2013[4]), pch=20, col="yellow")
lines(years, c(df$X2005[4],df$X2010[4],df$X2011[4],df$X2012[4],df$X2013[4]), pch=20, col="yellow")

points(years, c(df$X2005[5],df$X2010[5],df$X2011[5],df$X2012[5],df$X2013[5]), pch=20, col="cyan")
lines(years, c(df$X2005[5],df$X2010[5],df$X2011[5],df$X2012[5],df$X2013[5]), pch=20, col="cyan")

points(years, c(df$X2005[6],df$X2010[6],df$X2011[6],df$X2012[6],df$X2013[6]), pch=20, col="violet")
lines(years, c(df$X2005[6],df$X2010[6],df$X2011[6],df$X2012[6],df$X2013[6]), pch=20, col="violet")

points(years, c(df$X2005[7],df$X2010[7],df$X2011[7],df$X2012[7],df$X2013[7]), pch=20, col="black")
lines(years, c(df$X2005[7],df$X2010[7],df$X2011[7],df$X2012[7],df$X2013[7]), pch=20, col="black")

points(years, c(df$X2005[8],df$X2010[8],df$X2011[8],df$X2012[8],df$X2013[8]), pch=20, col="grey")
lines(years, c(df$X2005[8],df$X2010[8],df$X2011[8],df$X2012[8],df$X2013[8]), pch=20, col="grey")


main <- "Регион"
location <- "topright"
labels <- c("Центральный", "Северо-Западный", "Южный федеральный",
            "Северо-Кавказский", "Приволжский", "Уральский",
            "Сибирский", "Дальневосточный")
colors <- c("red3", "blue", "green", "yellow", "cyan", "violet", "black", "grey")


legend(location, labels, title = main, fill=colors)


pie(df$X2005, df$Регион)