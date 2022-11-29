package com.github.kiulian.downloader.cipher;


import java.util.List;
import java.util.Map;
import java.util.Objects;

public class DefaultCipher implements Cipher {

    private final Map<String, CipherFunction> functionsMap;
    private final List<JsFunction> functions;

    public DefaultCipher(List<JsFunction> transformFunctions, Map<String, CipherFunction> transformFunctionsMap) {
        this.functionsMap = transformFunctionsMap;
        this.functions = transformFunctions;
    }

    @Override
    public String getSignature(String cipheredSignature) {
        char[] signature = cipheredSignature.toCharArray();
        for (JsFunction jsFunction : functions) {
            signature = Objects.requireNonNull(functionsMap.get(jsFunction.getName())).apply(signature, jsFunction.getArgument());
        }
        return String.valueOf(signature);
    }

}
