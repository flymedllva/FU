# 1

df <- mtcars

# А почему они не равны :/
outer(df[, seq_len(ncol(df))], df[, seq_len(ncol(df))], function(X, Y){
  mapply(function(...) cor.test(..., na.action = "na.exclude")$estimate, X, Y)
}) == cor(df)

cor(df)
pairs(mtcars)

cor(df$mpg, df$hp)
ggplot(df, aes(x=mpg, y=hp)) + geom_point(size=3) + geom_smooth(method = lm)
ggplot(df, aes(x = mpg, y = carb, colour=qsec)) +
  geom_point() +
  stat_smooth(data=subset(df, qsec>10),
              method = "lm", se = T) +
  stat_smooth(data=subset(df, qsec>15),
              method = "loess", se = T)

cor(df$gear, df$hp)
ggplot(df, aes(x=gear, y=hp)) + geom_point(size=3) + geom_smooth(method = lm)
ggplot(df, aes(x = gear, y = carb, colour=qsec)) +
  geom_point() +
  stat_smooth(data=subset(df, qsec>10),
              method = "lm", se = T) +
  stat_smooth(data=subset(df, qsec>15),
              method = "loess", se = T)

cor(df$wt, df$hp)
ggplot(df, aes(x=wt, y=hp)) + geom_point(size=3) + geom_smooth(method = lm)
ggplot(df, aes(x = wt, y = carb, colour=qsec)) +
  geom_point() +
  stat_smooth(data=subset(df, qsec>10),
              method = "lm", se = T) +
  stat_smooth(data=subset(df, qsec>15),
              method = "loess", se = T)

# 2
df$carbb <- factor(df$carb, labels = c("1carb", "2carb", "3carb", "4carb", "5carb", "6carb"))
f_lm <- lm(mpg ~ carbb, df)
summary(f_lm)

# 3
library(corrgram)
corrgram(mtcars, order=NULL, lower.panel=panel.shade,
         upper.panel=NULL,
         main="Car Milage Data (unsorted)")

# 4
swiss <- data.frame(swiss)
summary(lm(Fertility ~ ., data = swiss))
summary(lm(Fertility ~ Infant.Mortality + Catholic + Education, data = swiss))

# 5
evals <- data.frame(read.csv("Занятия/evals.csv", encoding = "UTF-8"))
summary(lm(score ~ gender + age + language, data = evals))
