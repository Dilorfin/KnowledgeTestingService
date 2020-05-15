export class EditTest {
    id: number;
    title: string;
    description: string;
    time: number;
    questions: EditQuestion[];
}

export class EditQuestion {
    id: number;
    testId: number;
    questionText: string;
    answers: EditAnswer[];
}

export class EditAnswer {
    id: number;
    questionId: number;
    answerText: string;
    isCorrect: boolean;
}