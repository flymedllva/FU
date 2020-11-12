d2 <- read.table(file = "dtz1.txt", header = TRUE)

x1 <- d2$x1
x2 <- d2$x2
x3 <- d2$x3
x4 <- d2$x4
y <- d2$y

m <- lm(y ~ x1 + x2 + x3 + x4)
m

s <- summary(m)
s

R2 <- s$r.squared
R2

Se <- s$sigma
Se

A <- sum(abs(s$residuals/y))*100/length(y)
A

#
Y2 <- 1/y
m2 <- lm(Y2 ~ x1 + x2 + x3 + x4)
s2 <- summary(m2)

R22 <- s2$r.squared
R22

Se2 <- s2$sigma
Se2

A2 <- sum(abs(s2$residuals/Y2))*100/length(y)
A2


# Показательная модель
Y <- log10(y)
M1 <- lm(Y ~ x1 + x2 + x3 + x4)
s1 <- summary(M1)
s1
a <- 10^1.359474
b1 <- 10^(-0.009792)
b2 <- 10^(-0.008295)
b3 <- 10^(0.012798)
b4 <- 10^(0.024739)
a;b1;b2;b3;b4

# Степенная модель

Y3 <- log10(y)
X1 <- log10(x1)
X2 <- log10(x2)
X3 <- log10(x3)
X4 <- log10(x4)
M23<- lm(Y3 ~ X1 + X2 + X3 +X4)
s3 <- summary(M23)
s3

# Гиперболическая модель

Y2 <- 1/y
M3 <- lm(Y2 ~ x1 + x2 + x3 + x4)
s3 <- summary(M3)
s3

