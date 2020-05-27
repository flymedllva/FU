# 1
x <- array(1:111,c(4,4,4,4), list(1:4,letters[1:4],1:4))
x

# 2
x[1,,]; x[,1,]; x[,,1]
x[1, "a", "b"]

# 3
g <- list(25, "25", TRUE, 1:25, matrix(1:25, nrow=5))
g

# 4
g[[2]]
g[2]
names(g) <- c('f', 's', 'z', 'q', 'e')
g$third
str(g)
g[['f']]


# 5
g[['25']][1]
g$f[1]
g[[5]][1,1]
g[[5]][,1]
g[['25']][1,]


# 6
f <- function(dim) matrix(rep(c(1, rep(0, times=dim)), times=dim)[1:(dim * dim)], nrow=dim)
f(10)