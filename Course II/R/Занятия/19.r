library(ggplot2)
library(colorspace)
library(ggplot2)
library(gridExtra)
library(MASS)

# 1
# 1.1.
df <- read.csv2("p.csv")
df["Тип"] <- "непродовльственные"
df[259:382,"Тип"] = "продовольственные"

# 1.2
type.f <- factor(df$`Тип`)
type.f
cat.f <- factor(df$`Категория`)

ggplot(df,aes(x=df$X2017,y=type.f)) + geom_boxplot()

f1 <- aov(X2017 ~ type.f, data = df)
summary(f1) # Цена товара в 2017 НЕ зависит от типа товара

# 1.3
ggplot(df,aes(x = df$X2017, y = cat.f)) + geom_boxplot()

f1 <- aov(X2017 ~ cat.f, data = df)
summary(f1) # Цена товара в 2017 НЕ зависит от категории товара

# 1.4
pd <- position_dodge(0.1)
ggplot(df, aes(x = df$X2017, y = df$`Категория`, color = df$`Тип`, group = df$`Категория`)) +
  stat_summary(fun.data = mean_cl_boot, geom = 'errorbar', width = 0.2, lwd = 0.8, position = pd)+
  stat_summary(fun.data = mean_cl_boot, geom = 'line', size = 1.5, position = pd) +
  stat_summary(fun.data = mean_cl_boot, geom = 'point', size = 5, position = pd, pch=15) +
  theme_bw()
f3 <- aov(df$X2017 ~ df$`Категория`*type.f, data=df)
summary(f3) # Цена товара в 2017 НЕ зависит от категории товара и типа

# 2
# 2.1
ChickWeight

Chicken.anova <- aov(weight ~ (Time * Diet) + Error(Chick/Time) + (Diet), data=ChickWeight)
summary(Chicken.anova)
# 3
# 3.1
data_train <- read.csv("train.csv")
data_test <- read.csv("test.csv")


colours <- rainbow_hcl(4, start = 30, end = 300)
ggplot(data_train, aes(x = factor(Survived, labels = c("Погиб", "Выжил")), 
                       y = Age, fill = factor(Survived, labels = c("Погиб", "Выжил")))) +
  geom_boxplot() + scale_fill_manual (values=colours[]) + guides(fill=guide_legend(title=NULL)) +
  ylab(NULL) + xlab(NULL)

ggbar + aes(x = factor(Embarked, labels = c("Cherbourg", "Queenstown", "Southampton")),
            fill = factor(Survived, labels = c("Погиб", "Выжил"))) +
  scale_fill_manual (values=colours[]) + guides(fill=guide_legend(title=NULL)) +
  ylab(NULL) + xlab("Порт отправления")

ggbar + aes(x = factor(Embarked, labels = c("Cherbourg", "Queenstown", "Southampton")),
            fill = factor(Pclass, labels = c("Первый", "Второй", "Третий"))) +
  scale_fill_manual (values=colours[]) + guides(fill=guide_legend(title="Класс каюты")) +
  ylab(NULL) + xlab("Порт отправления")

corplot_data <- data_train %>%
  select(Survived, Pclass, Sex, Age, SibSp, Parch, Fare, Embarked) %>% mutate(Survived = as.numeric(Survived), Pclass = as.numeric(Pclass), Sex = as.numeric(Sex), Embarked = as.numeric(Embarked))
corr_train_data <- cor(corplot_data, use = "na.or.complete")
colsc <- c(rgb(241, 54, 23, maxColorValue=255), 'white', rgb(0, 61, 104, maxColorValue=255))
colramp <- colorRampPalette(colsc, space='Lab')
colorscor <- colramp(100)
my.plotcorr(corr_train_data, col=colorscor[((corr_train_data + 1)/2) * 100], upper.panel="number", mar=c(1,2,1,1), main='Корреляция между признаками')


