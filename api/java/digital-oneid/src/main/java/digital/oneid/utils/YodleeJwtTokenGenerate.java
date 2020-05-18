/** *******************************************************
 * Copyright (c) 2020, OneID.
 * All rights reserved.
 * ********************************************************/

package digital.oneid.utils;

import io.fusionauth.jwt.Signer;
import io.fusionauth.jwt.domain.JWT;
import io.fusionauth.jwt.rsa.RSASigner;
import joptsimple.OptionException;
import joptsimple.OptionParser;
import joptsimple.OptionSet;
import java.io.IOException;
import java.time.ZoneOffset;
import java.time.ZonedDateTime;
import java.util.Arrays;

/**
 * YodleeJwtTokenGenerate class mainly for generate the JWT token.
 * @author Hubino
 * @version 1.0
 * @since 10/03/2020
 */
public class YodleeJwtTokenGenerate {
    private static String issuerId;
    private static String privateKey;
    String [] args;

    public YodleeJwtTokenGenerate(String[] args) {
        this.args = args;
    }

    private static String getKey(String file) throws IOException {

        return new String(file.getBytes());
    }

    public String generateJwtYodlee(Boolean tokenGenration, String username) throws IOException {
        OptionSet options = getOptions(args);

        privateKey = getKey((String)options.valueOf("key"));
        issuerId = (String)options.valueOf("issuer-id");


        Signer signer = RSASigner.newSHA512Signer(privateKey);
        JWT jwt = null;
        if(tokenGenration) { // Application TOken Generation
            jwt = new JWT().setIssuer(issuerId)
                    .setIssuedAt(ZonedDateTime.now(ZoneOffset.UTC))
                    .setExpiration(ZonedDateTime.now(ZoneOffset.UTC).plusMinutes(30));
        } else { // User token generation
            jwt = new JWT().setIssuer(issuerId)
                    .setSubject(username)
                    .setIssuedAt(ZonedDateTime.now(ZoneOffset.UTC))
                    .setExpiration(ZonedDateTime.now(ZoneOffset.UTC).plusMinutes(30));
        }

        String encodedJWT = JWT.getEncoder().encode(jwt, signer);
        System.out.println(encodedJWT);
        return encodedJWT;
    }

    /**
     *
     * @param arguments
     * @return
     * @throws IOException
     */
    public static OptionSet getOptions(String[] arguments) throws IOException {
        OptionParser optionParser = new OptionParser();
        OptionSet optionSet;
        optionParser.acceptsAll(Arrays.asList("k", "key")).withRequiredArg().required();
        optionParser.acceptsAll(Arrays.asList("i", "issuer-id")).withRequiredArg().required();
        optionParser.acceptsAll(Arrays.asList("u", "username")).withRequiredArg();

        try {
            optionSet = optionParser.parse(arguments);
        } catch(OptionException ex) {
            optionParser.printHelpOn(System.out);
            throw new RuntimeException();
        }

        if (optionSet.has("help")) {
            optionParser.printHelpOn(System.out);
        }

        return optionSet;
    }
}
