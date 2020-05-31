library(ggplot2)
library(dplyr)
library(psych)

# 1

fit <- lm(mpg ~ ., mtcars)
f1 <- step(fit, direction = "backward")
summary(step(fit, direction = "backward"))

# Скорость разгона, тип коробки передач, вес автомобиля

# 2

pairs(mtcars)
ggplot(mtcars, aes(mpg, wt)) + geom_point() + geom_smooth()
ggplot(mtcars, aes(mpg)) + geom_histogram()
ggplot(mtcars, aes(wt)) + geom_histogram()
f2 <- lm(mpg~wt + am + qsec, mtcars)
summary(lm(mpg~wt + am + qsec, mtcars))

anova(f1, f2)

mtcars$lm1_fitted = f1$fitted
mtcars$lm1_resid = f1$residuals
ggplot(mtcars, aes(mpg, wt)) + geom_point() + geom_line(aes(x = lm1_fitted, y = wt), col = "blue") + geom_line(aes(x = mpg, y = wt), col = "red") + geom_smooth()

# 3

ggplot(mtcars, aes(lm1_fitted, lm1_resid)) + geom_point() + geom_smooth()
# Остатки распределены более менее равномерно.
hist(mtcars$lm1_resid)
# Распределение немного скошено влево, но в близко к нормальному
