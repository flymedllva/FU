# Модель логистической регрессии в R
# Загружаем данные
train <- read.csv('train.csv')
# Создаем обучающую и тестовую выборки из наших данных
install.packages('caTools')
library(caTools)
set.seed(88)
split <- sample.split(train$Recommended, SplitRatio = 0.75)
# Создаем обучающую и тестовую выборки
dresstrain <- subset(train, split == TRUE)
dresstest <- subset(train, split == FALSE)
# Модель логистической регрессии
model <- glm(Recommended ~ . - ID, data = dresstrain, family = binomial)
summary(model)
predict <- predict(model, type = 'response')
# Матрица ошибок
table(dresstrain$Recommended, predict > 0.5)
# ROCR-кривая
library(ROCR)
ROCRpred <- prediction(predict, dresstrain$Recommended)
ROCRperf <- performance(ROCRpred, 'tpr', 'fpr')
plot(ROCRperf, colorize = TRUE, text.adj = c(-0.2, 1.7))
# Строим график glm
library(ggplot2)
ggplot(dresstrain, aes(x = Rating, y = Recommended)) + geom_point() + stat_smooth(method = "glm", family = "binomial", se = FALSE)
# ROCR
# Инсталлируйте пакет ROCR
# Пример 1
data(ROCR.simple)
pred <- prediction(ROCR.simple$predictions, ROCR.simple$labels)
perf <- performance(pred, "tpr", "fpr")
plot(perf)
# Пример 2
perf <- performance(pred, "acc")
plot(perf)
# Пример 3
perf <- performance(pred, "ecost")
plot(perf)
# Пример 4
perf <- performance(pred, "auc")
# Пример 5
# Пример с одной выборкой
perf <- performance(pred, "tpr", "fpr")
par(bg = "lightblue", mai = c(1.2, 1.5, 1, 1))
plot(perf, main = "ROCR fingerpainting toolkit", colorize = TRUE, xlab = "fpr", ylab = "tpr",
     box.lty = 7, box.lwd = 5, xaxis.col = "blue", xaxis.col.axis = "blue", yaxis.col = "blue",
     yaxis.at = c(0, 0.5, 0.8, 0.85, 0.9, 1), yaxis.las = 1, xaxis.lwd = 2, yaxis.lwd = 2, yaxis.col.axis = "blue",
     cex.lab = 2, cex.main = 2)
# 3. ROCR
# Пример с несколькими выборками
# Пример 1
data(ROCR.xval)
pred <- prediction(ROCR.xval$predictions, ROCR.xval$labels)
perf <- performance(pred, "tpr", "fpr")
plot(perf, col = "black", lty = 3)
# Пример 2
plot(perf, lwd = 3, avg = "vertical", spread.estimate = "boxplot", add = TRUE)