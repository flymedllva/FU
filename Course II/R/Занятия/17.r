# 1

evals <- data.frame(read.csv("evals.csv", encoding = "UTF-8"))
evals$score2 <- cut(evals$score, 2, labels=c('low', 'high'))
head(evals)
t <- table(evals$score2, evals$rank)
prop.table(t)
prop.table(t, 1)
prop.table(t, 2)

barplot(t, legend.text = TRUE, beside = TRUE)

# 2

mtcars$t <- cut(mtcars$hp, 3, labels=c('low', 'middle', 'high'))
t <- table(mtcars$gear, mtcars$t)
prop.table(t)
prop.table(t, 1)
prop.table(t, 2)
barplot(t, legend.text = TRUE, beside = TRUE)
# Ну вроде как чем меньше скорость, тем больше тяга :/

# 3

df <- subset(iris, Species!="virginica")
table(df$Species)
ggplot(df, aes(x=Petal.Length, col=Species)) + geom_density()
shapiro.test(x=df$Petal.Length)