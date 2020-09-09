
text <- "B; D; B; NA; B; F; E; B; F; NA; A; C; A; F; D; E; C; A; E; C; E; E; F; D; A; E; C; C; A; F; E; NA; NA; B; E; A; F; B; E; C; E; E; D; E; C; B; C; E; C; D; NA; E; F; C; B; A; A; B; B; B; E; E; B; F; D; B; E; B; F; NA; A; E; A; NA; B; C; NA; A; F; F; A; B; F; D; NA; NA; E; B; B; D; F; E; E; A; E; C; A; NA; C; NA; E; D; F; NA; E; NA; F; F; A; D; A; NA; B; NA; E; E; F; NA; A; A; E; A; C; D; E; NA; E; F; E; E; C; E; F; F; C; E; C; C; NA; NA; NA; NA; E; E; B; B; E; NA; E; A; F; F; NA; F; NA; F; A; B; B; B; E; B; B; D; B; D; E; D; D; B; B; E; E; F; A; D; E; NA; A; F; E; NA; NA; NA; F; NA; C; A; B; A; C; E; NA; D; B; A; C; A; E; E; D; E; A; F; D; F; B; F; D; NA; E; E; B; NA; B; C; B; A; F; D; E; A; E; NA; A; E; E; B; D; F; F; A; E; E; A; B; B; F; NA; C; NA; E; D; NA; F; NA; E; F; D; NA; B; NA; E; A; NA; A; B; E; D; B; B; A; D; D; D; F; F; NA; E; NA; D; D; E; E; E; B; E; F; D; C; B; D; F; D; E; C; A; E; A; NA; A; NA; A; E; A; NA; E; E; B; E; D; E; F; C; E; NA; F; E; F; C; F; B; NA; NA; C; B; A; B; D; E"

library(DescTools)
library(ggplot2)

convert_text_task_2 <- function(text) {
  text <- unlist(strsplit(text, "; "))
  factor(replace(text, text == "NA", NA))
}

task2 <- convert_text_task_2(text)
na <- length(task2[is.na(task2)])


length(levels(task2)) # 1. Введите количество различных вариантов ответов респондентов, встречающиеся в очищенной выборке
task2 <- na.omit(task2); length(task2) # 2. Введите объем очищенной от "NA" выборки
na # 3. Введите количество пропущенных данных "NA" в исходной выборке
length(which(task2 == "B")) / length(task2) # 4. Введите долю респондентов, которые дали ответ "B"

a <- BinomCI(length(which(task2 == "B")), length(task2), conf.level = 0.9, sides = "two.sided", method = "wald")
a[3] # 5. Введите правую границу 0.9-доверительного интервала для истинной доли ответов  "B"
a[2] # 6. Введите левую границу 0.9-доверительного интервала для истинной доли ответов  "B"

# На уровне значимости 0.1 проверьте критерием согласия (Хи-квадрат критерием Пирсона)
# гипотезу о равновероятном распределении ответов респондентов.
qchisq(0.1, length(levels(task2)) - 1, lower.tail = F)  # 7. Введите критическое значение статистики хи-квадрат
chisq.test(table(task2))$parameter # 8. Введите количество степеней свободы
chisq.test(table(task2))$statistic # 9. Введите наблюдаемое значение хи-квадрат
ifelse(chisq.test(table(task2))$p.value < 0.05, 1, 0) # 10. Введите 1, если есть основания отвергнуть гипотезу о равновероятном распределении ответов, или введите 0, если таких оснований нет.

# 11. Постройте на листе "Лист2" гистограмму для исходной выборки, очищенной от "NA". Если построения произведены в R(RStudio), то скопируйте полученные диаграммы из RStudio на "Лист2".
ggplot(data.frame(table(task2)), aes(task2, Freq)) + geom_bar(stat = "identity") + xlab("Вариант") + ylab("Частота")
