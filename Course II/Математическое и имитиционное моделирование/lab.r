pow <- function(mat, x) {
  res <- mat
  for (i in 1:x) {
    res <- res %*% mat
  }
  res
}

second_pow <- function(mat, x) {
    if (x < 2) {
    return(mat)
  }
  res <- mat
  temp_res <- res
  for (o in 2:x) {
    for (i in 1:nrow(mat)) {
      for (j in 1:ncol(mat)) {
        s <- 0
        for (k in 1:nrow(mat)) {
          s <- s + if (k != j) mat[i, k] * res[k, j] else 0
        }
        temp_res[i, j] <- s
      }
    }
    res <- temp_res
  }
  res
}

sum_sec_pow <- function(mat, n) {
  if (n < 2) {
    return(mat)
  }
  res <- mat
  for (i in 2:n) {
    res <- res + second_pow(mat, i)
  }
  return(res)
}

sum_mult_sec_pow <- function(mat, n) {
  if (n < 2) {
    return(mat)
  }
  res <- mat
  for (i in 2:n) {
    res <- res + second_pow(mat, i) * i
  }
  return(res)
}


mat <- matrix(c(0.2, 0.7, 0.1, 0.4, 0, 0.6, 0.4, 0.3, 0.3), 3, 3)
mat <- t(mat)
mat
solve(mat)
pow(mat, 40)
pow(mat, 2)
second_pow(mat, 100)

sum_sec_pow(mat, 100)
sum_mult_sec_pow(mat, 50)
mat
mat <- matrix(c(0.5, 0.4, 0.1, 0.25, 0.25, 0.5, 0.1, 0.2, 0.7), 3, 3)


get_diag <- function(mat){
  t <- vector()
  for (i in 1:nrow(mat)){
    t<-c(t, mat[i, i])
  }
  t
}

get_p <- function(mat, n){
  get_diag(pow(mat, n))
}

get_f <- function(mat, k){
  if (k==1){
    return(get_diag(mat))
  }
  s <- get_p(mat, k)
  l <- k - 1
  for (m in 1:l){
    s <- s - get_f(mat, m)*get_p(mat, k-m)
  }
  s
}

get_diag2 <- function(mat){
  for (i in 1:nrow(mat)){
    for (j in 1:nrow(mat)){
      if (i!=j){
        mat[i,j]<-0
      }
    }
  }
  mat
}

get_p2 <- function(mat, n){
  get_diag2(pow(mat, n))
}

get_f2 <- function(mat, k){
  if (k==1){
    return(get_diag2(mat))
  }
  s <- get_p2(mat, k)
  l <- k - 1
  for (m in 1:l){
    s <- s - get_f2(mat, m)*get_p2(mat, k-m)
  }
  s
}

get_f2(mat, 5)
get_f(mat, 5)
