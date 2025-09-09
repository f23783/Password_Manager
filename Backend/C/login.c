#include <linux/limits.h>
#include <stdio.h>
#include <openssl/sha.h>
#include <string.h>
#include <stdlib.h>

__attribute__((visibility("default"))) void login_hash(char* user_name, char* user_masterkey){
	unsigned char digest[SHA256_DIGEST_LENGTH];
	SHA256((const unsigned char* )user_masterkey, strlen(user_masterkey), digest);

	for (int i = 0; i < SHA256_DIGEST_LENGTH; i++) {
		printf("%02x", digest[i]);
	}
	printf("\n");
}

