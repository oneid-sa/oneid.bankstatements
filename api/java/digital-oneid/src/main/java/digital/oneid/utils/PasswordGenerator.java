package digital.oneid.utils;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public final class PasswordGenerator {

    private static final String LOWER = "abcdefghijklmnopqrstuvwxyz";
    private static final String UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static final String DIGITS = "0123456789";
    private static final String PUNCTUATION = "!@#$%&*()_+-=[]|,./?><";
    private boolean useLower;
    private boolean useUpper;
    private boolean useDigits;
    private boolean usePunctuation;
    private boolean repeatingCaharactersAllowed;

    private PasswordGenerator() {
        throw new UnsupportedOperationException("Empty constructor is not supported.");
    }

    private PasswordGenerator(PasswordGeneratorBuilder builder) {
        this.useLower = builder.useLower;
        this.useUpper = builder.useUpper;
        this.useDigits = builder.useDigits;
        this.usePunctuation = builder.usePunctuation;
        this.repeatingCaharactersAllowed = builder.repeatingCaharactersAllowed;
    }

    public static class PasswordGeneratorBuilder {

        private boolean useLower;
        private boolean useUpper;
        private boolean useDigits;
        private boolean usePunctuation;
        private boolean repeatingCaharactersAllowed;


        public PasswordGeneratorBuilder() {
            this.useLower = false;
            this.useUpper = false;
            this.useDigits = false;
            this.usePunctuation = false;
            this.repeatingCaharactersAllowed = false;
        }

        /**
         * Set true in case you would like to include lower characters
         * (abc...xyz). Default false.
         *
         * @param useLower true in case you would like to include lower
         * characters (abc...xyz). Default false.
         * @return the builder for chaining.
         */
        public PasswordGeneratorBuilder useLower(boolean useLower) {
            this.useLower = useLower;
            return this;
        }


        public PasswordGeneratorBuilder repeatingCaharactersAllowed(boolean RepeatingCaharactersAllowed) {
            this.repeatingCaharactersAllowed = RepeatingCaharactersAllowed;
            return this;
        }

        /**
         * Set true in case you would like to include upper characters
         * (ABC...XYZ). Default false.
         *
         * @param useUpper true in case you would like to include upper
         * characters (ABC...XYZ). Default false.
         * @return the builder for chaining.
         */
        public PasswordGeneratorBuilder useUpper(boolean useUpper) {
            this.useUpper = useUpper;
            return this;
        }

        /**
         * Set true in case you would like to include digit characters (123..).
         * Default false.
         *
         * @param useDigits true in case you would like to include digit
         * characters (123..). Default false.
         * @return the builder for chaining.
         */
        public PasswordGeneratorBuilder useDigits(boolean useDigits) {
            this.useDigits = useDigits;
            return this;
        }

        /**
         * Set true in case you would like to include punctuation characters
         * (!@#..). Default false.
         *
         * @param usePunctuation true in case you would like to include
         * punctuation characters (!@#..). Default false.
         * @return the builder for chaining.
         */
        public PasswordGeneratorBuilder usePunctuation(boolean usePunctuation) {
            this.usePunctuation = usePunctuation;
            return this;
        }

        /**
         * Get an object to use.
         *
         * @return the {@link digital.oneid.utils.PasswordGenerator}
         * object.
         */
        public PasswordGenerator build() {
            return new PasswordGenerator(this);
        }
    }



    public String generateYodleeSpecific(int Length)
    {
        StringBuilder password = new StringBuilder(Length);
        List<String> charCategories = new ArrayList<>(1);
        charCategories.add(UPPER);
        Random random = new Random(System.nanoTime());
        String charCategory = charCategories.get(random.nextInt(charCategories.size()));
        int position = random.nextInt(charCategory.length());
        password.append(charCategory.charAt(position));
        charCategories.clear();
        charCategories.add(LOWER);
        char currentChar = 0;
        char previousChar = 0;
        for (int i=0;i<=3;i++)
        {
            boolean istheSame = true;
            while (istheSame)
            {
                charCategory = charCategories.get(random.nextInt(charCategories.size()));
                position = random.nextInt(charCategory.length());
                currentChar = charCategory.charAt(position);
                istheSame = (currentChar==previousChar);
            }
            password.append(currentChar);
            previousChar=currentChar;
        }

        password.append("@");
        charCategories.clear();
        charCategories.add(DIGITS);

        for (int i=0;i<=2;i++)
        {
            boolean istheSame = true;
            while (istheSame)
            {
                charCategory = charCategories.get(random.nextInt(charCategories.size()));
                position = random.nextInt(charCategory.length());
                currentChar = charCategory.charAt(position);
                istheSame = (currentChar==previousChar);
            }
            password.append(currentChar);
            previousChar=currentChar;
        }

        return new String(password);
    }

    /**
     * This method will generate a password depending the use* properties you
     * define. It will use the categories with a probability. It is not sure
     * that all of the defined categories will be used.
     *
     * @param length the length of the password you would like to generate.
     * @return a password that uses the categories you define when constructing
     * the object with a probability.
     */
    public String generate(int length) {
        // Argument Validation.
        if (length <= 0) {
            return "";
        }

        // Variables.
        StringBuilder password = new StringBuilder(length);
        Random random = new Random(System.nanoTime());

        // Collect the categories to use.
        List<String> charCategories = new ArrayList<>(4);
        if (useLower) {
            charCategories.add(LOWER);
        }
        if (useUpper) {
            charCategories.add(UPPER);
        }
        if (useDigits) {
            charCategories.add(DIGITS);
        }
        if (usePunctuation) {
            charCategories.add(PUNCTUATION);
        }

        char previousChar=0;
        char currentChar=1;
        // Build the password.
        for (int i = 0; i < length; i++) {

            boolean istheSameChar = true;

            if (!repeatingCaharactersAllowed) {
                while (istheSameChar) {
                    String charCategory = charCategories.get(random.nextInt(charCategories.size()));
                    int position = random.nextInt(charCategory.length());
                    currentChar = charCategory.charAt(position);

                    istheSameChar = (currentChar==previousChar);
                }
                password.append(currentChar);
                previousChar = currentChar;
            } else
            {
                String charCategory = charCategories.get(random.nextInt(charCategories.size()));
                int position = random.nextInt(charCategory.length());
                currentChar = charCategory.charAt(position);
                password.append(currentChar);
            }
        }
        return new String(password);
    }
}
