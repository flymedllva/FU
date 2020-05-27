
library(ggplot2)
library(psych)

# 1
str(mtcars)
head(mtcars)
describe(mtcars)
ggplot(data = mtcars, aes(x = am == 1, y = wt)) + geom_boxplot()
ggplot(data = mtcars, aes(x = wt < 3, y = mpg)) + geom_boxplot()
ggplot(data = mtcars, aes(x = gear == 3, y = mpg)) + geom_boxplot()
ggplot(data = mtcars, aes(x = am == 1, y = mpg)) + geom_boxplot()

# 2
evals <- data.frame(read.csv("evals.csv", encoding = "UTF-8"))
head(evals)
describe(evals)
ggplot(data = evals, aes(x = age < 45, y = score)) + geom_boxplot()
ggplot(data = evals, aes(x = rank, y = score)) + geom_boxplot()
ggplot(data = evals, aes(x = gender, y = score)) + geom_boxplot()
ggplot(data = evals, aes(x = language, y = cls_students)) + geom_boxplot()

# 3
ggplot(data = mtcars, aes(x = wt, y = qsec, color = gear, size = am, alpha = 0.5)) +
geom_point() + labs(x = "Вес", y = "Время разгона, секунд") +
scale_color_continuous("Колво передач", breaks = 3:5) +
scale_size("КПП", breaks = c(0, 1)) + geom_abline() + geom_line()

# 4
str(evals)
head(evals)
describe(evals)
ggplot(data = evals, aes(x = score)) + 
stat_count(aes(fill = cls_students), geom = "point")
# Колчество оценок зависит от самой оценки
ggplot(data = evals, aes(x = gender, y = score)) + geom_boxplot()
# Мужчины ставят оценки выше
ggplot(data = evals, aes(x = ethnicity, y = score)) + geom_boxplot()
# Белые ставят оценкки выше
ggplot(data=evals,
       aes(x=age<=20, y=score))+
  geom_boxplot()
# Преподаватели старше 20 ставят оценки ниже
# Чтобы получить оценку выше надо учиться у белого преподавателя моложе 20 лет