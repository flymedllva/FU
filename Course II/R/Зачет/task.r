library(rootSolve)
library(corrgram)

# 1.1. Создать клон dataframe, переставив столбцы в обратном порядке
mtcars[ncol(mtcars):1]
# 1.2. Создать клон dataframe, выбрав только первые три столбца
mtcars[1:3]
# 1.3. Создать клон dataframe, выполнив сортировку по первому столбцу
mtcars[with(mtcars, order(mpg)),]
# 1.4. Создать клон dataframe, выбрав строки с mpg>20 и carb=2
mtcars[mtcars$mpg > 20 & mtcars$carb == 2,]
# 2.1. Вычислить площадь фигуры, ограниченной линиями y=2x-x2; y=-x
y1 <- function(x) 2 * x - x ^ 2;
y2 <- function(x) -x;
(uni <- uniroot.all(y1, c(-10, 10)))
abs(as.numeric(integrate(y2, lower=uni[1], upper=uni[2])$value))- abs(as.numeric(integrate(y1, lower=uni[1], upper=uni[2])$value))
# 3
# 3.1
f1 <- function(x) x / (x ^ 2 + 4)
curve(f1, -5,5)
abline(v=0,lty=3)
abline(h=0,lty=3)
optimize(f1,c(-5,5))
optimize(f1,c(-5,5), maximum = T)
# 3.2
f2 <- function(x) (x ^ 3) * sqrt(x - 1)
curve(f2, -5,10)
abline(v=0, lty=3)
abline(h=0, lty=3)
optimize(f2, c(-10,15))
optimize(f2, c(-10,15), maximum = T)

# 4 Аналитика
# 4.1.1.Содержание озона в атмосферном воздухе
airquality
boxplot(airquality$Ozone)
# 4.1.2. Солнечная радиация Solar.R
airquality$Solar.R
# 4.1.3 Средняя скорость ветра Wind
mean(airquality$Wind)
# 4.1.4 Температура атмосферного воздуха Temp
airquality$Temp
plot(airquality$Ozone, airquality$Temp)
# 4.1.5 Cодержание озона Ozone
airquality$Ozone
# 4.1.6.месяц
airquality$Month
# 4.1.7.день
airquality$Day
# 4.3.1. Коэффициенты корреляции
cor(airquality)
# Температура имеет кореляцию с ветром и месяцем
# 4.3.2. Кореллограммы
corrgram(airquality, order=TRUE, lower.panel=panel.shade, upper.panel=panel.pie, text.panel=panel.txt)
# 4.3.3. Регрессию
summary(lm(Ozone ~ Wind + Temp + Solar.R, airquality))
# Содержание озона зависит от других парамтеров: Wind + Temp + Solar.R

# 5.1. Загрузить набор данных nassCDS.csv
nassCDS <- read.csv('nassCDS.csv')
# 5.2. При необходимости перевести переменные в факторы
nassCDS$frontal <- factor(nassCDS$frontal)
# 5.3. Определить степень влияния каждой переменной и взаимодействие переменных на смертность
head(nassCDS)
xtabs(weight ~ dead + airbag, data=nassCDS)
pairs(nassCDS)
# 5.4. Одинаковая ли степень влияния переменных в группах:
fit <- lm(weight ~ ., nassCDS)
# 6.1 Создать произвольную квадратную матрицу, заполненную последовательностью чисел.
a <- matrix(1:25, nrow = 5, byrow = T)
a
# 6.2 Реализовать механизм добавления одной ячейки в произвольное место (row, column) с выбором сдвига (по горизонтали, вертикали)
shift <- function(df, i, j, type = 1) {
  if (type == 1) {
      df <- rbind(df, matrix(ncol = ncol(df), nrow = 1))
      temp <- NA
      for (n_i in i:(ncol(df) + 1)) {
        temp2 <- df[n_i, j]
        df[n_i, j] <- temp
        temp <- temp2
      }
  } else {
      df <- cbind(df, matrix(ncol = 1, nrow = nrow(df)))
      temp <- NA
      for (n_j in j:(nrow(df) + 1)) {
        temp2 <- df[i, n_j]
        df[i, n_j] <- temp
        temp <- temp2
      }
  }
  return (df)
}
# Заполняем все NA, а потом просто периписываем все, что можно. Определенно не лучший вариант
shift(a, 3, 3, 2)
shift(a, 3, 2, 1)
shift(a, 1, 3, 2)


