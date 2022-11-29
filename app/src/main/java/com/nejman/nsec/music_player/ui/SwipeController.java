package com.nejman.nsec.music_player.ui;

import android.view.MotionEvent;

import io.reactivex.rxjava3.disposables.Disposable;
import io.reactivex.rxjava3.functions.Consumer;
import io.reactivex.rxjava3.subjects.PublishSubject;
import io.reactivex.rxjava3.subjects.Subject;

public class SwipeController {
    private static final int SWIPE_MIN_DISTANCE = 120;
    private static final int SWIPE_MAX_OFF_PATH = 250;
    private static final int SWIPE_THRESHOLD_VELOCITY = 200;
    private float startX;
    private float startY;
    private Subject<Boolean> swipeLeft;
    private Subject<Boolean> swipeRight;
    private boolean swiping;
    private boolean swipedLeft;
    private boolean swipedRight;

    public SwipeController() {
        swipeLeft = PublishSubject.create();
        swipeRight = PublishSubject.create();
    }

    public boolean isSwiping() {
        return swiping;
    }

    public Disposable addOnSwipeLeft(Consumer<Boolean> consumer) {
        return swipeLeft.subscribe(consumer);
    }

    public Disposable addOnSwipeRight(Consumer<Boolean> consumer) {
        return swipeRight.subscribe(consumer);
    }

    public boolean dispatchTouchEvent(MotionEvent event) {
        int action = event.getActionMasked();

        switch (action) {
            case MotionEvent.ACTION_DOWN:
                startX = event.getX();
                startY = event.getY();
                swipedLeft = false;
                swipedRight = false;
                break;
            case MotionEvent.ACTION_MOVE:
                boolean right = event.getX() - startX > SWIPE_MIN_DISTANCE;
                boolean left = startX - event.getX() > SWIPE_MIN_DISTANCE;
                swiping = left || right;
                if (left) {
                    if (!swipedLeft) {
                        swipeLeft.onNext(true);
                        swipedLeft = true;
                    }
                    return true;
                } else if (right) {
                    if (!swipedRight) {
                        swipeRight.onNext(true);
                        swipedRight = true;
                    }
                    return true;
                }
                break;
            case MotionEvent.ACTION_UP:
                if (swiping) {
                    swiping = false;
                    return true;
                }
                break;
        }

        return false;
    }
}
