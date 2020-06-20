
text <- "C; D; D; A; E; F; NA; E; B; F; B; D; NA; NA; E; C; E; NA; F; A; F; D; NA; F; D; E; F; B; A; E; E; C; A; D; NA; D; B; E; F; A; F; NA; E; E; NA; F; B; B; C; A; F; B; NA; D; E; E; B; D; F; F; E; E; E; NA; B; A; B; A; F; C; NA; A; C; F; A; E; A; B; F; B; B; E; NA; B; A; A; B; F; D; E; E; B; B; E; B; B; F; D; D; E; A; E; D; B; F; C; E; F; E; A; NA; NA; E; B; D; F; E; C; NA; B; B; NA; D; B; A; NA; F; F; C; B; B; A; C; A; E; E; A; E; A; F; E; F; A; E; F; A; E; B; A; NA; F; F; A; E; E; E; B; A; F; E; E; B; B; A; E; A; A; F; E; A; E; C; A; E; NA; F; E; D; A; F; NA; E; D; C; NA; A; F; NA; NA; F; E; E; C; A; F; B; E; A; F; NA; A; F; E; A; E; D; F; A; A; B; F; F; E; B; E; A; F; E; E; B; E; D; A; NA; A; E; F; F; B; B; E; NA; NA; F; B; C; A; E; C; A; B; B; F; A; D; F; A; B; E; F; E; NA; E; A; F; NA; E; E; E; E; B; A; E; E; C; E; A; F; NA; F; A; C; A; B; E; B; E; E; E; A; B; E; E; A; D; E; C; F; B; D; NA; E; A; F; B; A; F; NA; NA; D; D; C; D; C; E; E; A; D; F; D; B; C; E; C; B; E; A; E; F; E"

library(DescTools)
library(ggplot2)

convert_text_task_2 <- function(text) {
  text <- unlist(strsplit(text, "; "))
  factor(replace(text, text == "NA", NA))
}

task2 <- convert_text_task_2(text)
na <- length(task2[is.na(task2)])

length(levels(task2)) # Количество различных вариантов
na # Количество пропущенных данных "NA" в исходной выборке
task2 <- na.omit(task2); length(task2) # Объем очищенной от "NA" выборки

length(which(task2 == "B")) # Количество респондентов, которые дали ответ "B"
length(which(task2 == "B")) / length(task2) # Долю респондентов, которые дали ответ "B"

a <- BinomCI(length(which(task2 == "B")), length(task2), conf.level = 0.9, sides = "two.sided", method = "wald")
a[2] # Левая граница 0.95-доверительного интервала для истинной доли ответов "Red"
a[3] # Правая граница 0.95-доверительного интервала для истинной доли ответов  "Red"

qchisq(0.05, length(levels(task2)) - 1, lower.tail = F) # Критическое значение статистики хи-квадрат на уровне 0.05
chisq.test(table(task2))$statistic # Наблюдаемое значение хи-квадрат = X-squared
# Введите критическое значение статистики хи-квадрат
chisq.test(table(task2))$parameter # Количество степеней свободы = df, наблюдаемое значение хи-квадрат
ifelse(chisq.test(table(task2))$p.value < 0.05, 1, 0) # 1, если есть основания отвергнуть гипотезу о равновероятном распределении ответов, или введите 0, если таких оснований нет.

ggplot(data.frame(table(task2)), aes(task2, Freq)) + geom_bar(stat = "identity") + xlab("Вариант") + ylab("Частота")