library(sandwich)
library(lmtest)
library(corrgram)

# Гриднев Д.В ПИ18-1
df <- read.table(file = "wage11.txt", header = TRUE, dec=',')

cor(df)
corrgram(df, order=TRUE, lower.panel=panel.shade,
  upper.panel=panel.pie, text.panel=panel.txt)

wage <- df$wage
educ <- df$educ
exper <- df$exper

m <- lm(wage ~ educ + exper, data=df)
m

# Доверительные интервалы
di <- confint(m, level = 0.95)
di

s0 <- summary(m)
s0
c0 <- confint(m, level=0.95)
c0

# остатки / ошибка апроксимации
e <- s0$residuals
# ошибка апроксимации
aprEduc <- (1 / length(educ)) * sum(abs(e / (wage))) * 100
aprExper <- (1 / length(exper)) * sum(abs(e / (wage))) * 100
# R^2
r <- s0$r.squared
# среднеквадратичная ошибка
estd <- s0$sigma

# Качество модели 0.2252 и это плохо))
# wage(i)^ = -3.39054 + educ(i) * 0.64427 + exper(i) * 0.07010
# Модель значима, т.к. p-value < 2.2e-16

# Эластичность
elastx1 <- s0$coefficients[2] * mean(educ) / mean(df$wage);
elastx2 <- s0$coefficients[3] * mean(exper) / mean(df$wage);
elastx1
elastx2

# Бета-коэф.
bc1 <- s0$coefficients[2] * sd(educ) / sd(df$wage)
bc2 <- s0$coefficients[3] * sd(exper) / sd(df$wage)
bc1
bc2

# Дельта-коэф.
dd1 <- s0$coefficients[2] * cor(educ, wage) / s0$r.squared;
dd2 <- s0$coefficients[3] * cor(exper, wage) / s0$r.squared;
dd1
dd2

# Построить 3 вида нелинейных моделей и выбрать лучшую (линейную тоже включаем в сравнение) На основе пунктов 1) и 3)

# Показательная модель
Y <- log10(wage)
M1 <- lm(Y ~ educ + exper)
s1 <- summary(M1)
s1

# Степенная модель
#Y3 <- log10(wage)
#X1 <- log10(educ)
#X2 <- log10(exper)
#M2 <- lm(Y3 ~ X1 + X2)
#s2 <- summary(M2)
#s2
#Оно в бесконечность уходит

# Гиперболическая модель
Y2 <- 1 / wage
M3 <- lm(Y2 ~ educ + exper)
s3 <- summary(M3)
s3

# Они все не особо хорошие Я бы выбрал по данным гиперболическую

dw <- dwtest(m) # Durbin-Watson test
dw
bp <- bptest(m, varformula = ~ educ + I(educ ^ 2) + exper + I(exper^2) ) # Breusch-Pagan test
bp
# гетероскедастичность 1, alpha > p-value
gq1 <- gqtest(m, order.by = ~ educ, fraction = 0.25) # Goldfeld-Quandt test
gq1
# гетероскедастичность 1, alpha > p-value
bg1 <- bgtest(m, order= 1) # Breusch-Godfrey test
bg2 <- bgtest(m, order= 2)
bg3 <- bgtest(m, order= 3)
bg1;bg2;bg3

# 1 автокорреляция есть при альфа 5 и 10
# 2 и 3 порядки: автокорр нет