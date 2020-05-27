install.packages('rootSolve')
library(rootSolve)

# 1
x1 <- 1
x2 <- 9
f1 <- function(x) { y <- sin(x + pi/4); return(y) }
plot(f1, x1, x2)
abline(h = 0, lty = 3)
u1 <- uniroot.all(f1, lower = x1, upper = x2, n = 5)
points(u1, y = rep(0, length(u1)), pch = 16, cex = 2)
u1

# 2
x1 <- -6
x2 <- -3
f2 <- function(x) { y <- log(x ^ 2 + 8 * x + 16, base = 3); return(y)}
plot(f2, x1, x2)
u <- uniroot(f2, lower = -5, upper = 5)
abline(h = 0, v = 0, lty = 3)
u <- uniroot.all(f2, lower = x1, upper = x2, n = 20)
u

# 3
x1 <- -10
x2 <- 10
a <- 5
f3 <- function(x) {y <- 1 / x ^ 2;; return(y)}
a <- abs(a)
lines(plot(f3, 0, x2), type = 'h')
abline(h = 0, v = 0, lty = 3)
integrate(f3, a, Inf)


# 4
x1 <- -3
x2 <- -x1
f4 <- function(x) { return(x * sqrt(9 - x ^ 2)) }
plot(f4, x1, x2, xlab="x", ylab="y", col="red"); abline(h = 0, v = 0, lty = 3)
lines(plot(f4, 0, x2, add = T), type = 'h')
u4 <- uniroot.all(f4, lower = x1, upper = x2)
u4
as.numeric(integrate(f4, lower = u4[2], upper = u4[3])[1])

# 5

x1 <- -3
f5_1 <- function(x) { return(4 - x ^ 2) }
f5_2 <- function(x) { return(x ^ 2 - 2 * x) }
f5 <- function(x) { return(4 - x ^ 2 - x ^ 2 + 2 * x) }
plot(f5_1, x1, -x1)
plot(f5_2, x1, -x1, add = T)
abline(h = 0, v = 0, lty = 3)
u5 <- uniroot.all(f5, lower = x1, upper = -x1)
u5_1 <- uniroot.all(f5_1, lower = x1, upper = -x1)
u5_2 <- uniroot.all(f5_2, lower = x1, upper = -x1)
as.numeric(integrate(f5_1, u5[1], u5_1[2])[1]) - as.numeric(integrate(
  f5_2, u5_2[1], u5_2[2])[1]) - as.numeric(integrate(f5_2, u5[1], u5_2[1])[1])

# 6
x1 <- -5
f6 <- function(x) { return(sin(x) * cos(x) ^ 2) }
plot(f6, x1, -x1)
abline(h = 0, v = 0, lty = 3)
abline(v = pi / 2, lty = 1)
integrate(f6, lower = sort(uniroot.all(f6, lower = x1, upper = -x1))[2], upper = pi / 2)$value

# 7
x1 <- -5
f7 <- function(x) { return( -(x ^ 2) + 5) }
t7 <- uniroot.all(f7, lower = x1, upper = -x1)
t7
plot(f7, x1, -x1)
abline(h = 0, v = 0, lty = 3)
abline(h = 0, v = -4, lty = 3)
abline(h = 0, v = -2, lty = 3)
abline(h = 0, v = 3, lty = 3)
abline(h = 0, v = 4, lty = 3)
lines(plot(f7, -4, t7[2], add = T), type = 'h')
lines(seq(3, 4, by = 0.05), apply(t(seq(3, 4, by = 0.05)), 1, f7), type = 'h')

a <- abs(as.numeric(integrate(f7, lower = -4, upper = t7[1])$value))
b <- abs(as.numeric(integrate(f7, lower = t7[1], upper = t7[2])$value))
c <- abs(as.numeric(integrate(f7, lower = 3, upper = 4)$value))

paste("Площадь первой части", a)
paste("Площадь второй части", b)
paste("Площадь третьей части", c)
paste("Сумма площадей трех частей", a + b + c)

# 8
x1 <- -10

# .1
f <- function(x) { return( x ^ 3 - 12 * x - 4) }
plot(f, x1, -x1)
abline(h = 0, v = 0, lty = 3)
optim(0, f, method = 'BFGS')$par

# .2
f2 <- function(x) { return((x + 1) / ((x - 1) ^ 2)) }
plot(f2, x1, -x1)
abline(h = 0, v = 0, lty = 3)
optim(0.7, f2, method = 'Nelder-Mead')$par
optim(0.9, f2, method = 'Nelder-Mead')$par

# .3
f8_3 <- function(x) { return(x / (9 - x)) }
plot(f8_3, x1, -x1)
abline(h = 0, v = 0, lty = 3)
optim(0, f8_3, method = 'BFGS')$par

# .4
f8_4 <- function(x) { return((x ^ 2) / (4 * x ^ 2 + 1)) }
plot(f8_4, x1, -x1)
abline(h = 0, v = 0, lty = 3)
optim(0, f8_4, method = 'BFGS')$par

# 9 / 10
x <- 3
y <- 5

z <- expression(sin(cos(4 * x + 23 * x ^ y) ^ 4) - 12 * x)
z
D(z, 'x')
eval(z)

v <- expression(tan(x * 12 ^ y) - 8 * x ^ 4 + 14 * y - 7)
v
D(v, 'x')
eval(v)