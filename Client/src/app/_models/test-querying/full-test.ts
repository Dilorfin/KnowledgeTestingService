export class FullTest {
    id: number;
    title: string;
    description: string;
    time: number;
    questions: Question[];
}

export class Answer {
    id: number;
    questionId: number;
    answerText: string;
}

export class Question {
    id: number;
    testId: number;
    questionText: string;
    answers: Answer[];
}