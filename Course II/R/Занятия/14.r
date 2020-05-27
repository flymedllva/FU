# 1

f1 <- function(x) {
  print(x)
  if (is.nan(x)) {
    return (-1)
  }
  if (is.integer(x)) {
    return (x)
  }
  if (is.character(x)) {
    return (length(x))
  }
  return (0)
}

apply(matrix(c("2", 2, NaN, 3.2), ncol=4), MARGIN = 2, FUN = f1)

# Что matrix, что c приводят обьекты к единому формату, charterter, и такие вещи не работают

# 2, 3
# Там нет выбросов :/

# 4
a <- matrix(c(1,2,3,4,5,6,0,3,1,0,7,4,4,4,3,3,1,1,-2,2,2,2,-2,2,1,0,9,0,8,0,1,-3,5,-5,3,2), ncol = 6)
a <- apply(a, 2, sum)

# 5
apply(mtcars, 2, mean)
lapply(mtcars,  mean)
# lapply применяет функцию к каждому компоненту

# 6 из за выбросов не считает первые 2 столбика.

sapply(airquality, mean)
sapply(airquality, mean, na.rm=TRUE) # Без выбросов

# 7
set.seed(4)
x <- sample(1:10, 4)
a <- outer(x, x, "*")

(a <- matrix(sapply(a, function(x) ifelse(x %% 2 != 0, NaN, x)), ncol = 4))
(a <- matrix(sapply(a, function(x) ifelse(is.nan(x), "0", x)), ncol = 4))

# 8
replicate(5, rnorm(2, mean = 0, sd = 1), 4)

# 9
(tapply(mtcars$disp, mtcars$carb, mean))
(by(mtcars$disp, mtcars$carb, mean))
# разварачивает по другому из за того, что by хочет dataframe

# 10
y <- x <- 1:5
outer(y, x, {function (x, y) paste0(x, "*", y, "=", x * y) })

