library("readxl")
library('ggm')

# 1
z1 <- read_excel("z18.xlsx", sheet = 1)
-cor(z1$`Рейтинг авиакомпании, y`, z1$`№ п/п`)

# 2
z2 <- read_excel("z18.xlsx", sheet = 2)
names(z2) <- c("r", "f", "u")
ggplot(z2, aes(r, f)) + geom_point()
cor.test(z2$r, z2$f)
ggplot(z2, aes(log(r), log(f))) + geom_point()
cor.test(log(z2$r), log(z2$f))

# 3
z3 <- read_excel("z18.xlsx", sheet = 3)
names(z3) <- c("number", "minimum", "salary")
cor.test(z3$minimum, z3$salary)
ggplot(z3, aes(minimum, salary)) + geom_point() + geom_smooth(method = "lm")
summary(lm(salary~minimum, z3))
# 76.9765 + m * 0.9204

# 4
z4 <- read_excel("z18.xlsx", sheet = 4)
names(z4) <- c("n", "x", "y", "group")
ggplot(z4, aes(y, x)) + geom_point() + geom_smooth(method = "lm")
summary(lm(y, x, data = z4))

cor.test(~x + y, data = z4, subset = group == "А")
cor.test(~x + y, data = z4, subset = group == "Б")
# Da

# 5
z5 <- read_excel("z18.xlsx", sheet = 5)

z5.mz <- subset(z5, z5$`Город` == "NYC")
z5.ml <- subset(z5, z5$`Город` == "LI")

mean(z5.mz$`Суммарный рейтинг`); median(z5.mz$`Суммарный рейтинг`)
mean(z5.ml$`Суммарный рейтинг`); median(z5.ml$`Суммарный рейтинг`)

sapply(z5.mz, function(x) quantile(x, c(0.25, 0.5), type = 1))
sapply(z5.ml, function(x) quantile(x, c(0.25, 0.5), type = 1))


max(z5.mz$`Суммарный рейтинг`, na.rm=TRUE) - min(z5.mz$`Суммарный рейтинг`, na.rm=TRUE)
max(z5.ml$`Суммарный рейтинг`, na.rm=TRUE) - min(z5.ml$`Суммарный рейтинг`, na.rm=TRUE)

sapply(z5.mz, function(x) var(x))
sapply(z5.ml, function(x) var(x))

corrgram(z5.mz, order=NULL, lower.panel=panel.shade)
corrgram(z5.ml, order=NULL, lower.panel=panel.shade)

cor.test(~z5.mz$`Обслуживание` + z5.mz$`Суммарный рейтинг`, data = z5.mz)
cor.test(~z5.ml$`Обслуживание` + z5.ml$`Суммарный рейтинг`, data = z5.ml)